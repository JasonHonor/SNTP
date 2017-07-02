namespace NetworkTime
{
    using System;
    using System.Threading;

    public class Program
    {
        public static int Main(string[] args)
        {
            //RunService();

            if (args.Length < 1)
            {
                Console.WriteLine("Usage: sntp.exe servername");
            }

            var timeServer = args[0];
            var client = new NtpClient(timeServer, 124);
            var response = client.SendAsync().Result;

            var clockOffset = response.GetSystemClockOffset();
            var adjustedDateTime = DateTime.Now.AddSeconds(clockOffset);
            var offsetSign = clockOffset >= 0 ? "+" : string.Empty;

            //2011-08-04 00:40:36.642222 (+0000) +0.006611 +/- 0.041061 psp-os1 149.20.68.26 s3 no-leap
            var output = string.Format(
                "{0} {1}{2}",
                adjustedDateTime.ToString("yyyy-MM-dd hh:mm:ss.ffffff"),
                offsetSign,
                clockOffset);

            Console.WriteLine(output);
            Console.WriteLine();
            Console.WriteLine(response.ToString());

            return 0;
        }

        public static void RunService()
        {
            var service = new SntpClientService();
            service.OnStart();
            Thread.Sleep(-1);
            service.OnStop();
        }
    }
}
