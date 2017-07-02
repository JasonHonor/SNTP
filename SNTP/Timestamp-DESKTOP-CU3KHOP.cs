namespace NetworkTime
{
    using System;

    public struct TimeStamp
    {
        public uint Seconds { get; }

        public uint Fraction { get; }

        public TimeStamp(DateTime time)
        {
            var timeSpan = time - Epoch.DateTime;

            this.Seconds = (uint)timeSpan.TotalSeconds;
            this.Fraction = (uint)((double)timeSpan.Milliseconds / 1000 * uint.MaxValue);
        }

        public TimeStamp(uint seconds, uint fraction)
        {
            this.Seconds = seconds;
            this.Fraction = fraction;
        }

        public TimeStamp(byte[] bytes, int startIndex)
        {
            var bitConverter = new ByteConverter(false);
            this.Seconds = bitConverter.ToUInt32(bytes, startIndex);
            this.Fraction = bitConverter.ToUInt32(bytes, startIndex + 4);
        }

        public DateTime ToDateTime()
        {
            return Epoch.DateTime.Add(this.ToTimeSpan());
        }

        public TimeSpan ToTimeSpan()
        {
            var fractionMilliseconds = (double)this.Fraction / uint.MaxValue * 1000;
            var timeSpan = TimeSpan.FromSeconds(this.Seconds) + TimeSpan.FromMilliseconds(fractionMilliseconds);
            return timeSpan;
        }

        public byte[] ToBytes()
        {
            throw new NotImplementedException();
        }
    }
}
