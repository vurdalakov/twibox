namespace Vurdalakov
{
    using Nancy;

    public class ApplicationModule : NancyModule
    {
        public ApplicationModule(WebServiceContext webServiceContext) : base("/app")
        {
            Get["/name"] = parameters => this.Response.AsJson(webServiceContext.MainForm.AppName);
            Get["/version"] = parameters => this.Response.AsJson(webServiceContext.MainForm.AppVersion);
            Get["/mode"] = parameters => this.Response.AsJson(webServiceContext.MainForm.Mode.ToString());
        }
    }
}
