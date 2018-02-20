namespace Vurdalakov
{
    using System;

    public class WebServiceContext
    {
        public MainForm MainForm { get; }

        public WebServiceContext(MainForm mainForm)
        {
            this.MainForm = mainForm;
        }
    }
}
