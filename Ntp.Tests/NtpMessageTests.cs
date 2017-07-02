
namespace NetworkTime.Ntp.Tests
{
    using System;
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class NtpMessageTests
    {
        [TestMethod]
        public void NtpMessageConstructorSetsVersionModeAndTransmitTimestamp()
        {
            byte version = 3;
            var mode = Mode.Client;
            var transmitTime = new DateTime(2016, 12, 11, 10, 9, 8, 7, DateTimeKind.Utc);

            var transmitTimestamp = new Timestamp(transmitTime);
            var message = new NtpMessage(version, mode, transmitTimestamp);

            Assert.AreEqual(version, message.VersionNumber);
            Assert.AreEqual(mode, message.Mode);
            Assert.AreEqual(transmitTime, message.TransmitTimestamp.ToDateTime());
        }
    }
}
