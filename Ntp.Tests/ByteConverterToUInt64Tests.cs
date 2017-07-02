namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterToUInt64Tests
    {
        [TestMethod]
        public void ToUInt64LittleEndianLesserByteIsOne()
        {
            ulong original = 1;
            var bytes = new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianLesserByteIsMax()
        {
            ulong original = 255;
            var bytes = new byte[] { 255, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianSecondByteIsOne()
        {
            ulong original = 256;
            var bytes = new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianSecondByteIsMax()
        {
            ulong original = 65280;
            var bytes = new byte[] { 0, 255, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianThirdByteIsOne()
        {
            ulong original = 65536;
            var bytes = new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianThirdByteIsMax()
        {
            ulong original = 16711680;
            var bytes = new byte[] { 0, 0, 255, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianFourthByteIsOne()
        {
            ulong original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianFourthByteIsMax()
        {
            ulong original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 255, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianMinValue()
        {
            ulong original = ulong.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64LittleEndianMaxValue()
        {
            ulong original = ulong.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianLesserByteIsOne()
        {
            ulong original = 1;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianLesserByteIsMax()
        {
            ulong original = 255;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianSecondByteIsOne()
        {
            ulong original = 256;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianSecondByteIsMax()
        {
            ulong original = 65280;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianThirdByteIsOne()
        {
            ulong original = 65536;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianThirdByteIsMax()
        {
            ulong original = 16711680;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 255, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianFourthByteIsOne()
        {
            ulong original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianFourthByteIsMax()
        {
            ulong original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 0, 255, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianMinValue()
        {
            ulong original = ulong.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt64BigEndianMaxValue()
        {
            ulong original = ulong.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt64(bytes, 0);
            Assert.AreEqual(original, result);
        }
    }
}
