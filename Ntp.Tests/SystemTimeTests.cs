namespace NetworkTime.Ntp.Tests
{
    using System;
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class SystemTimeTests
    {
        [TestMethod]
        public void SystemTimeFromDateTime()
        {
            var dateTime = new DateTime(2016, 11, 11, 5, 55, 55, 500);
            var systemTime = new SystemTime(dateTime);

            Assert.AreEqual(dateTime.Year, systemTime.Year);
            Assert.AreEqual(dateTime.Month, systemTime.Month);
            Assert.AreEqual(dateTime.Day, systemTime.Day);
            Assert.AreEqual(dateTime.Hour, systemTime.Hour);
            Assert.AreEqual(dateTime.Minute, systemTime.Minute);
            Assert.AreEqual(dateTime.Second, systemTime.Second);
            Assert.AreEqual(dateTime.Millisecond, systemTime.Milliseconds);
            Assert.AreEqual((ushort)dateTime.DayOfWeek, systemTime.DayOfWeek);
        }

        [TestMethod]
        public void SystemTimeToDateTime()
        {
            var dateTime = new DateTime(2016, 11, 11, 5, 55, 55, 500, DateTimeKind.Utc);
            var systemTime = new SystemTime(dateTime);

            var toDateTime = systemTime.ToDateTime(DateTimeKind.Utc);

            Assert.AreEqual(dateTime, toDateTime);
        }
    }
}
