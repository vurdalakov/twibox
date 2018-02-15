namespace Vurdalakov
{
    using System;
    using System.Diagnostics;

    public class ElapsedTime
    {
        private String _name;
        private Int64 _startTicks;

        public ElapsedTime(String name = "")
        {
            this._name = name;

            this.Reset();
        }

        public void Reset()
        {
            this._startTicks = DateTime.Now.Ticks;
        }

        public void Lapse()
        {
            var ms = (DateTime.Now.Ticks - this._startTicks) / 10000;
            Trace.WriteLine($"{this._name} {ms}ms");
        }
    }
}
