namespace Vurdalakov
{
    using System;
    using static DebugTracing;

    public class PipeServer : NamedPipeServer
    {
        private readonly String _baseUrl;
        private readonly MainForm _mainForm;

        public PipeServer(String baseUrl, MainForm mainForm) : base("DarkboxInfo")
        {
            this._baseUrl = baseUrl;
            this._mainForm = mainForm;
        }

        protected override void OnClientConnected() { Trace("OnClientConnected"); }
        protected override void OnClientDisconnected() { Trace("OnClientDisconnected"); }

        protected override void OnMessageReceived(String message)
        {
            Trace($"OnMessageReceived({message})");

            if (!String.IsNullOrEmpty(message))
            {
                switch (message.ToLower())
                {
                    case "baseurl":
                        Send(this._baseUrl);
                        break;
                    case "popup":
                        this._mainForm.InvokeIfRequired(() => this._mainForm.BringToFront());
                        Send("OK");
                        break;
                    default:
                        Send($"Unknown command '{message}'");
                        break;
                }
            }
        }
    }
}
