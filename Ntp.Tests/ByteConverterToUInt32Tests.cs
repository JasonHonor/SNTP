namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterToUInt32Tests
    {
        [TestMethod]
        public void ToUInt32LittleEndianLesserByteIsOne()
        {
            uint original = 1;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianLesserByteIsMax()
        {
            uint original = 255;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianSecondByteIsOne()
        {
            uint original = 256;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianSecondByteIsMax()
        {
            uint original = 65280;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianThirdByteIsOne()
        {
            uint original = 65536;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianThirdByteIsMax()
        {
            uint original = 16711680;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianFourthByteIsOne()
        {
            uint original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianFourthByteIsMax()
        {
            uint original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianMinValue()
        {
            uint original = uint.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32LittleEndianMaxValue()
        {
            uint original = uint.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianLesserByteIsOne()
        {
            uint original = 1;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianLesserByteIsMax()
        {
            uint original = 255;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianSecondByteIsOne()
        {
            uint original = 256;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianSecondByteIsMax()
        {
            uint original = 65280;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianThirdByteIsOne()
        {
            uint original = 65536;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianThirdByteIsMax()
        {
            uint original = 16711680;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianFourthByteIsOne()
        {
            uint original = 16777216;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianFourthByteIsMax()
        {
            uint original = 4278190080;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianMinValue()
        {
            uint original = uint.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt32BigEndianMaxValue()
        {
            uint original = uint.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }
    }
}
