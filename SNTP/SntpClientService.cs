namespace NetworkTime
{
    using System;
    using System.Configuration;
    using System.Threading;
    using System.Threading.Tasks;

    public class SntpClientService : IDisposable
    {
        private readonly Configuration config;

        private CancellationTokenSource cancellationTokenSource;

        private string server;
        private int port = 123;
        private bool updateClock = true;
        private int maxCorrection = 86400; // In milliseconds
        private int minCorrection = 1000; // In milliseconds
        private int pollingInterval = 82800; // In seconds (23 hours)

        private Task pollingTask;

        public SntpClientService()
        {
            this.config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this.LoadSettings();
        }

        public void OnStart()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.pollingTask = this.PollForTime();
        }

        public void OnStop()
        {
            if (this.cancellationTokenSource != null)
            {
                this.cancellationTokenSource.Cancel();
            }

            if (this.pollingTask != null)
            {
                this.pollingTask.Wait();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
            {
                return;
            }

            if (this.cancellationTokenSource != null)
            {
                this.cancellationTokenSource.Dispose();
            }
        }

        protected async Task PollForTime()
        {
            while (!this.cancellationTokenSource.Token.IsCancellationRequested)
            {
                Console.WriteLine("Requesting time data from the time source {0}.", this.server);

                var client = new NtpClient(this.server, this.port);
                var response = await client.SendAsync();
                var offset = response.GetSystemClockOffset();

                Console.WriteLine("Received time data from the time source {0}. The difference from the system time is {1} seconds.", this.server, offset);

                this.SetLastPollTime(DateTime.UtcNow);

                // Update system time
                if (this.ShouldSetClock(TimeSpan.FromSeconds(offset)))
                {
                    IClock clock = new WindowsClock();
                    Console.WriteLine("Synchronizing the system time with time source {0}.", this.server);
                    var clockSet = clock.SetTimeUtc(DateTime.UtcNow.AddSeconds(offset));
                    if (clockSet)
                    {
                        this.SetLastUpdateTime(DateTime.UtcNow);
                        Console.WriteLine("The system time was updated by {0} seconds.", offset);
                    }
                    else
                    {
                        var error = clock.GetLastError();
                        Console.WriteLine("The system time could not be updated. Error code: {0}.", error);
                    }
                }

                Console.WriteLine(response.ToString());

                await Task.Delay(TimeSpan.FromSeconds(this.pollingInterval));
            }
        }

        #region Private methods

        private bool ShouldSetClock(TimeSpan offset)
        {
            if (!this.updateClock)
            {
                Console.WriteLine("System time synchronization has been disabled in the configuration.");
                return false;
            }

            if (this.maxCorrection < Math.Abs(offset.TotalMilliseconds))
            {
                Console.WriteLine("The system time will not be updated because the time difference exceeds the maximum correction time allowed.");
                return false;
            }

            if (this.minCorrection > Math.Abs(offset.TotalMilliseconds))
            {
                Console.WriteLine("The system time will not be updated because the time difference does not meet the minimum correction time allowed.");
                return false;
            }

            return true;
        }

        private void SetLastPollTime(DateTime time)
        {
            this.config.AppSettings.Settings["LastPollTime"].Value = time.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss:ffff");
            this.config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("AppSettings");
        }

        private void SetLastUpdateTime(DateTime time)
        {
            this.config.AppSettings.Settings["LastUpdateTime"].Value = time.ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss:ffff");
            this.config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("AppSettings");
        }

        private void LoadSettings()
        {
            var serverConfig = ConfigurationManager.AppSettings["TimeServer"];
            if (!string.IsNullOrWhiteSpace(serverConfig))
            {
                this.server = serverConfig;
            }
            else
            {
                throw new ApplicationException("No time server was configured");
            }

            var portConfig = ConfigurationManager.AppSettings["LocalPort"];
            if (!string.IsNullOrWhiteSpace(portConfig))
            {
                this.port = Convert.ToInt32(portConfig);
            }

            var updateClockConfig = ConfigurationManager.AppSettings["DoNotUpdateClock"];
            if (!string.IsNullOrWhiteSpace(updateClockConfig))
            {
                this.updateClock = Convert.ToBoolean(updateClockConfig);
            }

            var maxCorrectionConfig = ConfigurationManager.AppSettings["MaxTimeCorrection"];
            if (!string.IsNullOrWhiteSpace(maxCorrectionConfig))
            {
                this.maxCorrection = Convert.ToInt32(maxCorrectionConfig);
            }

            var minCorrectionConfig = ConfigurationManager.AppSettings["MinTimeCorrection"];
            if (!string.IsNullOrWhiteSpace(minCorrectionConfig))
            {
                this.minCorrection = Convert.ToInt32(minCorrectionConfig);
            }

            var pollingIntervalConfig = ConfigurationManager.AppSettings["PollingInterval"];
            if (!string.IsNullOrWhiteSpace(pollingIntervalConfig))
            {
                this.pollingInterval = Convert.ToInt32(pollingIntervalConfig);
            }
        }

        #endregion
    }
}
