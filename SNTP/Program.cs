namespace NetworkTime
{
    using log4net;
    using log4net.Core;
    using System;
    using System.Reflection;
    using System.ServiceProcess;
    using System.Threading;

    public class Program
    {
        public static int Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            log.Debug("Service starting.");

            if (args.Length < 1)
            {
                RunService();
                return 0;
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

            log.Debug(output);
            log.Debug(response.ToString());

            return 0;
        }

        public static void RunService()
        {
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Debug("RunService");

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SntpClientService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
