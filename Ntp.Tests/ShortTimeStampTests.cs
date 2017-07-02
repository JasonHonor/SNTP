namespace NetworkTime.Ntp.Tests
{
    using System;
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ShortTimestampTests
    {
        [TestMethod]
        public void ShortTimestampFromBytes()
        {
            const float seconds = 100.5f;

            var converter = new ByteConverter(false);
            var temp = (uint)(seconds * Constants.TwoPow16);
            var bytes = converter.GetBytes(temp);

            var timestamp = new ShortTimestamp(bytes, 0);
            Assert.AreEqual(seconds, timestamp.Seconds);
        }

        [TestMethod]
        public void ShortTimestampToBytes()
        {
            const float seconds = 100.5f;
            const uint value = (uint)(seconds * Constants.TwoPow16);

            var converter = new ByteConverter(false);
            var expectedBytes = converter.GetBytes(value);

            var timestamp = new ShortTimestamp(seconds);
            CollectionAssert.AreEqual(expectedBytes, timestamp.ToBytes());
        }

        [TestMethod]
        public void ShortTimestampFromTimeSpanAndToTimeSpanAreEqual()
        {
            var timespan = new TimeSpan(0, 0, 0, 100, 500);
            var timestamp = new ShortTimestamp(timespan);

            Assert.AreEqual(timespan, timestamp.ToTimeSpan());
        }
    }
}
