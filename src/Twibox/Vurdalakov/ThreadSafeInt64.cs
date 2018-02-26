namespace Vurdalakov
{
    using System;
    using System.Threading;

    public class ThreadSafeInt64
    {
        private Int64 _value = 0;

        public Boolean IsZero()
        {
            return 0 == Interlocked.Read(ref this._value);
        }

        public void Increment()
        {
            Interlocked.Increment(ref this._value);
        }

        public void Decrement()
        {
            Interlocked.Decrement(ref this._value);
        }

        public Int64 Read()
        {
            return Interlocked.Read(ref this._value);
        }
    }
}
