namespace Vurdalakov
{
    using System;
    using System.IO.Pipes;
    using System.Text;
    using static DebugTracing;

    // https://github.com/IfatChitin/Named-Pipes/blob/master/ClientServerUsingNamedPipes/ClientServerUsingNamedPipes/Server/InternalPipeServer.cs
    public class NamedPipeServer
    {
        private String _pipeName;
        private NamedPipeServerStream _pipeServer;
        private Boolean _isStopping = false;
        private Object _lockObject = new Object();

        public NamedPipeServer(String pipeName)
        {
            this._pipeName = pipeName;
        }

        protected virtual void OnClientConnected() { }
        protected virtual void OnClientDisconnected() { }
        protected virtual void OnMessageReceived(String message) { }

        public Boolean Start()
        {
            Trace("Start");

            _isStopping = false;

            try
            {
                this._pipeServer = new NamedPipeServerStream(this._pipeName, PipeDirection.InOut, 16, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                _pipeServer.BeginWaitForConnection(WaitForConnectionCallBack, null);
                return true;
            }
            catch (Exception ex)
            {
                Trace(ex, "BeginWaitForConnection");
                return false;
            }
        }

        public Boolean Stop()
        {
            if (null == _pipeServer)
            {
                return true;
            }

            Trace("Stop");

            _isStopping = true;

            try
            {
                if (_pipeServer.IsConnected)
                {
                    _pipeServer.Disconnect();
                }

                return true;
            }
            catch (Exception ex)
            {
                Trace(ex, "Disconnect");
                return false;
            }
            finally
            {
                try
                {
                    _pipeServer.Close();
                    _pipeServer.Dispose();
                }
                catch (Exception ex)
                {
                    Trace(ex, "Close");
                }
                finally
                {
                    _pipeServer = null;
                }
            }
        }

        private void WaitForConnectionCallBack(IAsyncResult result)
        {
            Trace("WaitForConnectionCallBack");
            if (!_isStopping)
            {
                lock (_lockObject)
                {
                    if (!_isStopping)
                    {
                        try
                        {
                            _pipeServer.EndWaitForConnection(result);

                            OnConnected();
                        }
                        catch (Exception ex)
                        {
                            Trace(ex, "EndWaitForConnection");
                        }

                        BeginRead(new ReadState());
                    }
                }
            }
        }

        private void BeginRead(ReadState readState)
        {
            Trace("BeginRead");
            try
            {
                _pipeServer.BeginRead(readState.Buffer, 0, readState.Buffer.Length, EndReadCallBack, readState);
            }
            catch (Exception ex)
            {
                Trace(ex, "BeginRead");
            }
        }

        private void EndReadCallBack(IAsyncResult result)
        {
            Trace("EndReadCallBack");
            try
            {
                var bytesRead = _pipeServer?.EndRead(result) ?? 0;
                if (bytesRead > 0)
                {
                    var readState = result.AsyncState as ReadState;

                    readState.StringBuilder.Append(Encoding.UTF8.GetString(readState.Buffer, 0, bytesRead));

                    if (_pipeServer.IsMessageComplete)
                    {
                        var message = readState.StringBuilder.ToString().TrimEnd('\0').TrimEnd();

                        OnMessageReceived(message);

                        BeginRead(new ReadState());
                    }
                    else
                    {
                        BeginRead(readState);
                    }
                }
                else
                {
                    if (!_isStopping)
                    {
                        lock (_lockObject)
                        {
                            if (!_isStopping)
                            {
                                OnDisconnected();

                                Stop();
                                Start();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace(ex, "EndRead");
            }
        }

        public Boolean Send(String message)
        {
            Trace("Send");
            try
            {
                if (!_pipeServer.IsConnected)
                {
                    Trace("Pipe is not connected");
                    return false;
                }

                if (message[message.Length - 1] != '\n')
                {
                    message += '\n';
                }

                var buffer = Encoding.UTF8.GetBytes(message);

                _pipeServer.BeginWrite(buffer, 0, buffer.Length, EndWriteCallBack, null);

                return true;
            }
            catch (Exception ex)
            {
                Trace(ex, "BeginWrite");
                return false;
            }
        }

        private void EndWriteCallBack(IAsyncResult result)
        {
            Trace("EndWriteCallBack");
            try
            {
                _pipeServer.EndWrite(result);
            }
            catch (Exception ex)
            {
                Trace(ex, "EndWrite");
            }
        }

        private class ReadState
        {
            public Byte[] Buffer { get; }
            public StringBuilder StringBuilder { get; }

            public ReadState()
            {
                this.Buffer = new byte[8192];
                this.StringBuilder = new StringBuilder();
            }
        }
    }
}
