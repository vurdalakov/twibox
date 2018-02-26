namespace Vurdalakov
{
    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Threading.Tasks;
    using Nancy.Hosting.Self;
    using static DebugTracing;

    public class WebService
    {
        private NancyHost _nancyHost;

        public void Start(MainForm mainForm)
        {
            this.Stop();

            try
            {
                var port = 61786;
                var baseUrl = $"http://localhost:{port}/api/";

                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        try
                        {
                            using (var server = new NamedPipeServerStream("DarkboxInfo"))
                            {
                                server.WaitForConnection();

                                var reader = new StreamReader(server);
                                var writer = new StreamWriter(server);

                                while (true)
                                {
                                    var line = reader.ReadLine();
                                    if (!String.IsNullOrEmpty(line))
                                    {
                                        switch (line.ToLower())
                                        {
                                            case "baseurl":
                                                writer.WriteLine(baseUrl);
                                                break;
                                            case "popup":
                                                mainForm.InvokeIfRequired(() => mainForm.BringToFront());
                                                writer.WriteLine("OK");
                                                break;
                                            default:
                                                writer.WriteLine("Unknown command");
                                                break;
                                        }
                                        writer.Flush();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Trace(ex, "Pipe error");
                        }
                    }
                });

                var hostConfiguration = new HostConfiguration();
                hostConfiguration.RewriteLocalhost = false;
                hostConfiguration.UnhandledExceptionCallback = ex => Trace(ex as Exception, "Unhandled web service exception");

                this._nancyHost = new NancyHost(new Uri(baseUrl), new WebServiceBootstrapper(mainForm), hostConfiguration);
                this._nancyHost.Start();
            }
            catch (Exception ex)
            {
                Trace(ex, "Cannot start web service");
                this.Stop();
            }
        }

        public void Stop()
        {
            if (this._nancyHost != null)
            {
                try
                {
                    this._nancyHost.Stop();
                    this._nancyHost.Dispose();
                    this._nancyHost = null;
                }
                catch (Exception ex)
                {
                    Trace(ex, "Cannot stop web service");
                }
            }
        }
    }
}
