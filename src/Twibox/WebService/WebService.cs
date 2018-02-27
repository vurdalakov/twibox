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
        private PipeServer _pipeServer;
        private NancyHost _nancyHost;

        public void Start(MainForm mainForm)
        {
            this.Stop();

            var port = 61786;
            var baseUrl = $"http://localhost:{port}/api/";

            try
            {
                this._pipeServer = new PipeServer(baseUrl, mainForm);
                this._pipeServer.Start();
            }
            catch (Exception ex)
            {
                Trace(ex, "Cannot start pipe service");
                this.Stop();
            }

            try
            {
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
            if (this._pipeServer != null)
            {
                try
                {
                    this._pipeServer.Stop();
                    this._pipeServer = null;
                }
                catch (Exception ex)
                {
                    Trace(ex, "Cannot stop pipe service");
                }
            }

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
