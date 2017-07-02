namespace NetworkTime
{
    using System;

    public struct ShortTimestamp
    {
        public float Seconds { get; }

        public ShortTimestamp(float seconds)
        {
            this.Seconds = seconds;
        }

        public ShortTimestamp(byte[] bytes, int startIndex)
        {
            this.Seconds = FromBytes(bytes, startIndex);
        }

        public ShortTimestamp(TimeSpan timeSpan)
        {
            this.Seconds = (float)timeSpan.TotalSeconds;
        }

        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromSeconds(this.Seconds);
        }

        public byte[] ToBytes()
        {
            return ToBytes(this.Seconds);
        }

        public static byte[] ToBytes(float seconds)
        {
            var converter = new ByteConverter(false);
            var temp = (uint)(seconds * Constants.TwoPow16);
            return converter.GetBytes(temp);
        }

        public static float FromBytes(byte[] bytes, int startIndex)
        {
            if (bytes.Length < startIndex + 4)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            var converter = new ByteConverter(false);
            var temp = converter.ToInt32(bytes, startIndex);
            return (float)temp / Constants.TwoPow16;
        }
    }
}
