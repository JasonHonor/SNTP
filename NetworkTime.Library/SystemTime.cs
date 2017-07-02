namespace NetworkTime
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// SYSTEMTIME structure used by SetSystemTime
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Milliseconds;

        public SystemTime(DateTime time)
        {
            this.Year = (ushort)time.Year;
            this.Month = (ushort)time.Month;
            this.DayOfWeek = (ushort)time.DayOfWeek;
            this.Day = (ushort)time.Day;
            this.Hour = (ushort)time.Hour;
            this.Minute = (ushort)time.Minute;
            this.Second = (ushort)time.Second;
            this.Milliseconds = (ushort)time.Millisecond;
        }

        public DateTime ToDateTime(DateTimeKind kind)
        {
            return new DateTime(
                this.Year,
                this.Month,
                this.Day,
                this.Hour,
                this.Minute,
                this.Second,
                this.Milliseconds,
                kind);
        }
    }
}
