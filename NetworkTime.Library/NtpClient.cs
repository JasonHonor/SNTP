namespace NetworkTime
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class NtpClient
    {
        private const int NtpPort = 123;
        private const byte NtpVersion = 4;

        public string Server { get; set; }

        public int Port { get; set; }

        public NtpClient(string server, int port = NtpPort)
        {
            this.Server = server;
            this.Port = port;
        }

        public async Task<NtpMessage> SendAsync()
        {
            var timeServerEndPoint = GetIPEndPoint(this.Server, NtpPort);

            NtpMessage responsePacket;
            Timestamp transmitTimestamp;
            using (var updClient = new UdpClient(this.Port))
            {
                updClient.Connect(timeServerEndPoint);

                transmitTimestamp = new Timestamp(DateTime.UtcNow);
                var ntpPacket = new NtpMessage(NtpVersion, Mode.Client, transmitTimestamp);
                var ntpRequestPayload = ntpPacket.GetBytes();

                await updClient.SendAsync(ntpRequestPayload, ntpRequestPayload.Length);

                // TODO Add timeout
                var response = await updClient.ReceiveAsync();
                responsePacket = new NtpMessage(response.Buffer, DateTime.UtcNow);
            }

            // Validate the response
            if (!ResponseIsValid(responsePacket, transmitTimestamp))
            {
                throw new InvalidOperationException("The response was not valid.");
            }

            return responsePacket;
        }

        private static bool ResponseIsValid(NtpMessage response, Timestamp transmitTimestamp)
        {
            if (response.Stratum == Stratum.Unspecified)
            {
                return false;
            }

            if (response.OriginateTimestamp.Seconds != transmitTimestamp.Seconds)
            {
                return false;
            }

            /*
             * https://tools.ietf.org/html/rfc4330
             * "4.  The server reply should be discarded if any of the LI, Stratum,
             * or Transmit Timestamp fields is 0 or the Mode field is not 4
             * (unicast) or 5 (broadcast)."
             * 
             * LI should not be 3?
             */
            //if (response.LeapIndicator == LeapIndicator.NoWarning)
            //{
            //    return false;
            //}

            if (response.Mode != Mode.Server)
            {
                return false;
            }

            if (response.TransmitTimestamp.Seconds == 0)
            {
                return false;
            }

            if (response.RootDelay.Seconds >= 1)
            {
                return false;
            }

            if (response.RootDispersion.Seconds >= 1)
            {
                return false;
            }

            return true;
        }

        private static IPEndPoint GetIPEndPoint(string hostName, int port, AddressFamily addressType = AddressFamily.InterNetwork)
        {
            if (string.IsNullOrWhiteSpace(hostName))
            {
                throw new ArgumentNullException(nameof(hostName));
            }

            var ipHostEntry = Dns.GetHostEntry(hostName);
            var ipAddress = ipHostEntry
                .AddressList
                .FirstOrDefault(currentAddress => currentAddress.AddressFamily == addressType);

            if (ipAddress == null)
            {
                throw new ArgumentException(nameof(hostName));
            }

            return new IPEndPoint(ipAddress, port);
        }
    }
}
