namespace NetworkTime
{
    using System;

    public static class Constants
    {
        public static DateTime Epoch = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public const ulong TwoPow16 = 65536;
        public const ulong TwoPow32 = 4294967296;
    }
}
