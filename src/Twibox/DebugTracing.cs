namespace Vurdalakov
{
    using System;
    using System.Diagnostics;

    public static class DebugTracing
    {
        public static void Trace(String message)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine(message);
            }
            catch { }
        }

        public static void Trace(Exception ex, String message = null)
        {
            try
            {
                if (!String.IsNullOrEmpty(message))
                {
                    Trace($"EXCEPTION: {message}");
                }

                Trace($"EXCEPTION: {ex.GetType().Name}: {ex.Message}");

#if DEBUG
                var stackFrame = new StackTrace(ex, true).GetFrame(0);
                var lineNumber = stackFrame.GetFileLineNumber();
                if (lineNumber > 0)
                {
                    Trace($"{stackFrame.GetFileName()}({lineNumber}): exception {ex.GetType().Name}: {ex.Message}");
                }
            }
            catch { }
#endif
        }
    }
}
