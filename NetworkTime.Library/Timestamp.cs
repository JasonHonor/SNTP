namespace NetworkTime
{
    using System;

    public struct Timestamp
    {
        public double Seconds { get; }

        public Timestamp(DateTime time)
        {
            this.Seconds = FromDateTime(time);
        }

        public Timestamp(double seconds)
        {
            this.Seconds = seconds;
        }

        public Timestamp(byte[] bytes, int startIndex)
        {
            this.Seconds = FromBytes(bytes, startIndex);
        }

        public DateTime ToDateTime()
        {
            return ToDateTime(this.Seconds);
        }

        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromSeconds(this.Seconds);
        }

        public byte[] ToBytes()
        {
            return ToBytes(this.Seconds);
        }

        public static double FromBytes(byte[] bytes, int startIndex)
        {
            if (bytes.Length < startIndex + 8)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            var converter = new ByteConverter(false);
            var bytesAsUInt64 = converter.ToUInt64(bytes, startIndex);

            return (double)bytesAsUInt64 / Constants.TwoPow32;
        }

        public static double FromDateTime(DateTime dateTime)
        {
            var timeSpan = dateTime - Constants.Epoch;
            return timeSpan.TotalSeconds;
        }

        public static byte[] ToBytes(double seconds)
        {
            var converter = new ByteConverter(false);
            var temp = (ulong)(seconds * Constants.TwoPow32);
            return converter.GetBytes(temp);
        }

        public static DateTime ToDateTime(double seconds)
        {
            return Constants.Epoch.AddSeconds(seconds);
        }
    }
}
