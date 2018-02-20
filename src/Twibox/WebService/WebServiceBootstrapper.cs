namespace Vurdalakov
{
    using Nancy;
    using Nancy.TinyIoc;

    public class WebServiceBootstrapper : DefaultNancyBootstrapper
    {
        private WebServiceContext _webServiceContext;

        public WebServiceBootstrapper(MainForm mainForm)
        {
            this._webServiceContext = new WebServiceContext(mainForm);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<WebServiceContext>(this._webServiceContext);
        }
    }
}
