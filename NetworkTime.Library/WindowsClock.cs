namespace NetworkTime
{
    using System;
    using System.Runtime.InteropServices;

    public class WindowsClock : IClock
    {
        /// <summary>
        /// Retrieves the current local date and time.
        /// </summary>
        /// <returns>A DateTime structure that contains the local date and time. DateTimeKind is Local.</returns>
        public DateTime GetTime()
        {
            SystemTime st;
            var result = NativeMethods.GetLocalTime(out st);

            return st.ToDateTime(DateTimeKind.Local);
        }

        /// <summary>
        /// Retrieves the current system date and time. The system time is expressed in Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>A DateTime structure that contains the local date and time. DateTimeKind is UTC.</returns>
        public DateTime GetTimeUtc()
        {
            SystemTime st;
            var result = NativeMethods.GetSystemTime(out st);

            return st.ToDateTime(DateTimeKind.Utc);
        }

        /// <summary>
        /// Sets the current local time and date.
        /// </summary>
        /// <param name="time">A DateTime structure that contains the new system date and time. DateTimeKind must be Local.</param>
        public bool SetTime(DateTime time)
        {
            if (time.Kind != DateTimeKind.Local)
            {
                throw new ArgumentException("Time must be in local time", nameof(time));
            }

            var st = new SystemTime(time);
            return NativeMethods.SetLocalTime(ref st);
        }

        /// <summary>
        /// Sets the current system time and date. The system time is expressed in Coordinated Universal Time (UTC).
        /// </summary>
        /// <param name="time">A DateTime structure that contains the new system date and time. DateTimeKind must be UTC.</param>
        public bool SetTimeUtc(DateTime time)
        {
            if (time.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Time must be UTC", nameof(time));
            }

            var st = new SystemTime(time);
            return NativeMethods.SetSystemTime(ref st);
        }

        public uint GetLastError()
        {
            return NativeMethods.GetLastError();
        }

        private static class NativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetLocalTime(out SystemTime time);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool GetSystemTime(out SystemTime time);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetLocalTime([In] ref SystemTime time);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern bool SetSystemTime([In] ref SystemTime time);

            [DllImport("kernel32.dll")]
            internal static extern uint GetLastError();
        }
    }
}
