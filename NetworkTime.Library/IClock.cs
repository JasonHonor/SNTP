namespace NetworkTime
{
    using System;

    public interface IClock
    {
        uint GetLastError();

        DateTime GetTime();

        DateTime GetTimeUtc();

        bool SetTime(DateTime time);

        bool SetTimeUtc(DateTime time);
    }
}