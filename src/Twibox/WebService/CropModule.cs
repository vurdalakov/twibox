namespace Vurdalakov
{
    using System;
    using Nancy;

    public class CropModule : NancyModule
    {
        public CropModule(WebServiceContext webServiceContext) : base("/api/app/mode/crop")
        {
            Put["/start"] = parameters => Call(webServiceContext.MainForm, () => webServiceContext.MainForm.EnableCropMode(true));
        }

        private IResponseFormatter Call(MainForm mainForm, Action action)
        {
            mainForm.InvokeIfRequired(action);
            return this.Response;
        }
    }
}
