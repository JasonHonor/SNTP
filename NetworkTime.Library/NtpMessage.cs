namespace NetworkTime
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Represents a NTP message packet
    /// </summary>
    public class NtpMessage
    {
        // Standard NTP header (https://tools.ietf.org/html/rfc5905)
        //                       1                   2                   3
        //   0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |LI | VN  |Mode |    Stratum    |     Poll      |   Precision   |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                          Root Delay                           |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                       Root Dispersion                         |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                     Reference Identifier                      |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                                                               |
        //  |                   Reference Timestamp (64)                    |
        //  |                                                               |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                                                               |
        //  |                   Originate Timestamp (64)                    |
        //  |                                                               |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                                                               |
        //  |                    Receive Timestamp (64)                     |
        //  |                                                               |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                                                               |
        //  |                    Transmit Timestamp (64)                    |
        //  |                                                               |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                 Key Identifier (optional) (32)                |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //  |                                                               |
        //  |                                                               |
        //  |                 Message Digest (optional) (128)               |
        //  |                                                               |
        //  |                                                               |
        //  +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

        #region Private fields

        private const byte NtpDataLength = 48;
        private const byte RootDelayStartIndex = 4;
        private const byte RootDispersionStartIndex = 8;
        private const byte ReferenceIdStartIndex = 12;
        private const byte ReferenceTimestampStartIndex = 16;
        private const byte OriginateTimestampStartIndex = 24;
        private const byte ReceiveTimestampStartIndex = 32;
        private const byte TransmitTimestampStartIndex = 40;

        #endregion Private fields

        #region Public Properties

        public LeapIndicator LeapIndicator { get; private set; }

        public byte VersionNumber { get; private set; }

        public Mode Mode { get; private set; }

        public Stratum Stratum { get; private set; }

        // Poll Interval (in seconds)
        public byte PollInterval { get; private set; }

        // Precision (in seconds)
        public byte Precision { get; private set; }

        public ShortTimestamp RootDelay { get; private set; }

        public ShortTimestamp RootDispersion { get; private set; }

        public string ReferenceId { get; private set; }

        public Timestamp ReferenceTimestamp { get; private set; }

        // Originate Timestamp (T1)
        public Timestamp OriginateTimestamp { get; private set; }

        // Receive Timestamp (T2)
        public Timestamp ReceiveTimestamp { get; private set; }

        // Transmit Timestamp (T3)
        public Timestamp TransmitTimestamp { get; private set; }

        // Destination Timestamp (T4)
        public Timestamp DestinationTimestamp { get; private set; }

        #endregion Public Properties

        #region Constructors

        public NtpMessage(byte versionNumber, Mode mode, Timestamp transmiteTimestamp)
        {
            this.VersionNumber = versionNumber;
            this.Mode = mode;
            this.TransmitTimestamp = transmiteTimestamp;
        }

        public NtpMessage(byte[] responseBytes, DateTime destinationTime)
        {
            this.DestinationTimestamp = new Timestamp(destinationTime);
            this.ParseBytes(responseBytes);
        }

        #endregion

        #region Public Methods

        public double GetRoundTripDelay()
        {
            var delayTimeSpan =
                (this.DestinationTimestamp.Seconds - this.OriginateTimestamp.Seconds)
                -
                (this.TransmitTimestamp.Seconds - this.ReceiveTimestamp.Seconds);

            return delayTimeSpan;
        }

        public double GetSystemClockOffset()
        {
            var offset =
                (this.ReceiveTimestamp.Seconds - this.OriginateTimestamp.Seconds)
                +
                (this.TransmitTimestamp.Seconds - this.DestinationTimestamp.Seconds);

            return offset / 2;
        }

        public byte[] GetBytes()
        {
            var ntpPacket = new byte[NtpDataLength];

            // Set Leap Indicator, Mode and Version
            var byte0 = (byte)((byte)this.LeapIndicator << 6 | (byte)this.Mode | (this.VersionNumber << 3));
            ntpPacket[0] = byte0;

            // Set Stratum
            ntpPacket[1] = (byte)this.Stratum;

            // Set Poll Interval
            ntpPacket[2] = this.PollInterval;

            // Set Precision
            ntpPacket[3] = this.Precision;

            // Set Root Delay
            var rootDelayTimestampBytes = this.RootDelay.ToBytes();
            rootDelayTimestampBytes.CopyTo(ntpPacket, RootDelayStartIndex);

            // Set RootDispersion
            var rootDispersionTimestampBytes = this.RootDispersion.ToBytes();
            rootDispersionTimestampBytes.CopyTo(ntpPacket, RootDispersionStartIndex);

            // TODO Set Reference ID

            // Set Reference Timestamp
            var referenceTimestampBytes = this.ReferenceTimestamp.ToBytes();
            referenceTimestampBytes.CopyTo(ntpPacket, ReferenceTimestampStartIndex);

            // Set Originate Timestamp
            var originateTimestampBytes = this.OriginateTimestamp.ToBytes();
            originateTimestampBytes.CopyTo(ntpPacket, OriginateTimestampStartIndex);

            // Set Receive Timestamp
            var receiveTimestampBytes = this.ReceiveTimestamp.ToBytes();
            receiveTimestampBytes.CopyTo(ntpPacket, ReceiveTimestampStartIndex);

            // Set Transmit Timestamp
            var timestampTimestampBytes = this.TransmitTimestamp.ToBytes();
            timestampTimestampBytes.CopyTo(ntpPacket, TransmitTimestampStartIndex);

            // TODO Add optional fields

            return ntpPacket;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Leap Indicator: " + (int)this.LeapIndicator);
            switch (this.LeapIndicator)
            {
                case LeapIndicator.NoWarning:
                    stringBuilder.AppendLine(" (No warning)");
                    break;
                case LeapIndicator.LastMinute61:
                    stringBuilder.AppendLine(" (Last minute has 61 seconds)");
                    break;
                case LeapIndicator.LastMinute59:
                    stringBuilder.AppendLine(" (Last minute has 59 seconds)");
                    break;
                case LeapIndicator.Alarm:
                    stringBuilder.AppendLine(" (Alarm Condition - clock not synchronized)");
                    break;
            }

            stringBuilder.Append("Stratum: " + (int)this.Stratum);
            switch (this.Stratum)
            {
                case Stratum.Unspecified:
                case Stratum.Reserved:
                    stringBuilder.AppendLine(" (Unspecified)");
                    break;
                case Stratum.PrimaryReference:
                    stringBuilder.AppendLine(" (Primary Reference)");
                    break;
                case Stratum.SecondaryReference:
                    stringBuilder.AppendLine(" (Secondary Reference)");
                    break;
            }

            stringBuilder.AppendLine("Version number: " + this.VersionNumber);
            stringBuilder.AppendLine("Mode: " + this.Mode);

            stringBuilder.AppendLine("Precision: " + this.Precision + " s");
            stringBuilder.AppendLine("Poll Interval: " + this.PollInterval + " s");
            stringBuilder.AppendLine("Reference ID: " + this.ReferenceId);
            stringBuilder.AppendLine("Root Delay: " + this.RootDelay.ToTimeSpan().TotalMilliseconds + " ms");
            stringBuilder.AppendLine("Root Dispersion: " + this.RootDispersion.ToTimeSpan().TotalMilliseconds + " ms");
            stringBuilder.AppendLine("Round Trip Delay: " + this.GetRoundTripDelay() + " s");
            stringBuilder.AppendLine("Local Clock Offset: " + this.GetSystemClockOffset() + " s");

            const string timeFormat = "yyyy-MM-dd hh:mm:ss.ffffff";
            stringBuilder.AppendLine("OriginateTimestamp: " + this.OriginateTimestamp.ToDateTime().ToString(timeFormat));
            stringBuilder.AppendLine("ReceiveTimestamp: " + this.ReceiveTimestamp.ToDateTime().ToString(timeFormat));
            stringBuilder.AppendLine("TransmitTimestamp: " + this.TransmitTimestamp.ToDateTime().ToString(timeFormat));
            stringBuilder.AppendLine("DestinationTimestamp: " + this.DestinationTimestamp.ToDateTime().ToString(timeFormat));

            return stringBuilder.ToString();
        }

        #endregion

        #region Private Methods

        private void ParseBytes(byte[] bytes)
        {
            this.LeapIndicator = (LeapIndicator)(bytes[0] >> 6);

            // Isolate bits 3 - 5
            this.VersionNumber = (byte)((bytes[0] >> 3) & 0x7);

            this.PollInterval = (byte)Math.Pow(2, (sbyte)bytes[2]);
            this.Precision = (byte)Math.Pow(2, (sbyte)bytes[3]);

            this.OriginateTimestamp = new Timestamp(bytes, OriginateTimestampStartIndex);
            this.ReferenceTimestamp = new Timestamp(bytes, ReferenceTimestampStartIndex);
            this.ReceiveTimestamp = new Timestamp(bytes, ReceiveTimestampStartIndex);
            this.TransmitTimestamp = new Timestamp(bytes, TransmitTimestampStartIndex);

            this.RootDelay = new ShortTimestamp(bytes, 4);
            this.RootDispersion = new ShortTimestamp(bytes, 8);

            this.Mode = GetMode(bytes);
            this.Stratum = GetStratum(bytes);

            this.ReferenceId = GetReferenceId(bytes, this.Stratum, this.VersionNumber);
        }

        private static Mode GetMode(byte[] bytes)
        {
            // Isolate bits 0 - 3
            var value = bytes[0] & 0x7;

            if (Enum.IsDefined(typeof(Mode), value))
            {
                return (Mode)value;
            }

            return Mode.Unknown;
        }

        private static Stratum GetStratum(byte[] bytes)
        {
            var value = (int)bytes[1];
            if (Enum.IsDefined(typeof(Stratum), value))
            {
                return (Stratum)value;
            }
            else if (value >= (int)Stratum.Reserved)
            {
                return Stratum.Reserved;
            }

            return Stratum.SecondaryReference;
        }

        private static string GetReferenceId(byte[] bytes, Stratum stratum, byte version)
        {
            var val = string.Empty;
            switch (stratum)
            {
                case Stratum.Unspecified:
                case Stratum.PrimaryReference:
                    val += (char)bytes[ReferenceIdStartIndex + 0];
                    val += (char)bytes[ReferenceIdStartIndex + 1];
                    val += (char)bytes[ReferenceIdStartIndex + 2];
                    val += (char)bytes[ReferenceIdStartIndex + 3];
                    break;
                case Stratum.SecondaryReference:
                    switch (version)
                    {
                        case 3: // Version 3, Reference ID is an IPv4 timeServerAddress
                            var address = bytes[ReferenceIdStartIndex + 0] + "." +
                                bytes[ReferenceIdStartIndex + 1] + "." +
                                bytes[ReferenceIdStartIndex + 2] + "." +
                                bytes[ReferenceIdStartIndex + 3];
                            try
                            {
                                var host = Dns.GetHostEntry(address);
                                val = host.HostName + " (" + address + ")";
                            }
                            catch (Exception)
                            {
                                val = address;
                            }

                            break;
                        case 4: // Version 4, Reference ID is the timestamp of last update
                            val = new Timestamp(bytes, ReferenceIdStartIndex)
                                .ToDateTime()
                                .ToString(CultureInfo.InvariantCulture);
                            break;
                        default:
                            val = "N/A";
                            break;
                    }

                    break;
            }

            return val;
        }

        #endregion Private Methods
    }
}
