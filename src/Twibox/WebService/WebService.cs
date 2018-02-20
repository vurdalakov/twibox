namespace Vurdalakov
{
    using System;
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
                var hostConfiguration = new HostConfiguration();
                hostConfiguration.RewriteLocalhost = false;
                hostConfiguration.UnhandledExceptionCallback = ex => Trace(ex as Exception, "Unhandled web service exception");

                this._nancyHost = new NancyHost(new Uri("http://localhost:61786/api/"), new WebServiceBootstrapper(mainForm), hostConfiguration);
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
