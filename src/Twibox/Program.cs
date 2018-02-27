namespace Vurdalakov
{
    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Threading;
    using System.Windows.Forms;
    using static DebugTracing;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            var mutex = new Mutex(true, "DarkboxApplication", out Boolean createdNew);
            if (!createdNew)
            {
                Trace("Darkbox application is already running");

                try
                {
                    using (var client = new NamedPipeClientStream("DarkboxInfo"))
                    {
                        client.Connect(2500);

                        var reader = new StreamReader(client);
                        var writer = new StreamWriter(client);

                        writer.WriteLine("popup");
                        writer.Flush();
                        var answer = reader.ReadLine();
                        Trace($"{answer}");
                    }
                }
                catch (Exception ex)
                {
                    Trace(ex, "Pipe client");
                }

                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
