namespace NetworkTime.Ntp.Tests
{
    using System;
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class TimestampTests
    {
        [TestMethod]
        public void NtpEpockAsTimestamp()
        {
            var unixEpock = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const uint expectedSeconds = 0;
            var timestamp = new Timestamp(unixEpock);

            Assert.AreEqual(expectedSeconds, timestamp.Seconds);
        }

        [TestMethod]
        public void UnixEpockAsTimestamp()
        {
            var unixEpock = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const uint expectedSeconds = 2208988800;
            var timestamp = new Timestamp(unixEpock);

            Assert.AreEqual(expectedSeconds, timestamp.Seconds);
        }

        [TestMethod]
        public void FirstDayOfUtcAsTimestamp()
        {
            var utcDayOne = new DateTime(1972, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const uint expectedSeconds = 2272060800;
            var timestamp = new Timestamp(utcDayOne);

            Assert.AreEqual(expectedSeconds, timestamp.Seconds);
        }

        [TestMethod]
        public void TimestampFromBytes()
        {
            var converter = new ByteConverter(false);

            var seconds = 1.5;
            var temp = (ulong)(seconds * Constants.TwoPow32);
            var bytes = converter.GetBytes(temp);

            var timestamp = new Timestamp(bytes, 0);
            Assert.AreEqual(seconds, timestamp.Seconds);
        }

        [TestMethod]
        public void TimestampToBytes()
        {
            var converter = new ByteConverter(false);

            var seconds = 1.5;
            var temp = (ulong)(seconds * Constants.TwoPow32);
            var expectedBytes = converter.GetBytes(temp);

            var timestamp = new Timestamp(seconds);
            CollectionAssert.AreEqual(expectedBytes, timestamp.ToBytes());
        }

        [TestMethod]
        public void TimestampToDateTime()
        {
            var unixEpock = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            const uint unixEpockSeconds = 2208988800;
            var timestamp = new Timestamp(unixEpockSeconds);

            Assert.AreEqual(unixEpock, timestamp.ToDateTime());
        }

        [TestMethod]
        public void TimestampToTimeSpan()
        {
            var unixEpockPlusHalfSecond = new DateTime(1970, 1, 1, 0, 0, 0, 500, DateTimeKind.Utc);

            var timestamp = new Timestamp(unixEpockPlusHalfSecond);
            var expectedTimeSpan = unixEpockPlusHalfSecond - Constants.Epoch;

            Assert.AreEqual(expectedTimeSpan, timestamp.ToTimeSpan());
        }
    }
}
