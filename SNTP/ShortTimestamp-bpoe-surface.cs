namespace NetworkTime
{
    using System;

    public struct ShortTimeStamp
    {
        public ushort Seconds { get; set; }

        public ushort Fraction { get; set; }

        public ShortTimeStamp(DateTime time)
        {
            var seconds = (time - Epoch.DateTime).TotalSeconds;
            this.Seconds = (ushort)seconds;
            this.Fraction = 0;
        }

        public ShortTimeStamp(ushort seconds, ushort fraction)
        {
            this.Seconds = seconds;
            this.Fraction = fraction;
        }

        public ShortTimeStamp(byte[] bytes, int startIndex)
        {
            var bitConverter = new ByteConverter(false);
            this.Seconds = bitConverter.ToUInt16(bytes, startIndex);
            this.Fraction = bitConverter.ToUInt16(bytes, startIndex + 2);
        }

        public TimeSpan ToTimeSpan()
        {
            var fractionMilliseconds = (double)this.Fraction / uint.MaxValue * 1000;
            var timeSpan = TimeSpan.FromSeconds(this.Seconds) + TimeSpan.FromMilliseconds(fractionMilliseconds);
            return timeSpan;
        }
    }
}
