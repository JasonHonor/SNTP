namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterToInt32Tests
    {
        [TestMethod]
        public void ToInt32LittleEndianLesserByteIsOne()
        {
            int original = 1;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianLesserByteIsMax()
        {
            int original = 255;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianSecondByteIsOne()
        {
            int original = 256;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianSecondByteIsMax()
        {
            int original = 65280;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianThirdByteIsOne()
        {
            int original = 65536;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianThirdByteIsMax()
        {
            int original = 16711680;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianFourthByteIsOne()
        {
            int original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianFourthByteIsMax()
        {
            int original = -16777216;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianMinValue()
        {
            int original = int.MinValue;
            var bytes = new byte[] { 0, 0, 0, 128 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32LittleEndianMaxValue()
        {
            int original = int.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 127 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianLesserByteIsOne()
        {
            int original = 1;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianLesserByteIsMax()
        {
            int original = 255;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianSecondByteIsOne()
        {
            int original = 256;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianSecondByteIsMax()
        {
            int original = 65280;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianThirdByteIsOne()
        {
            int original = 65536;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianThirdByteIsMax()
        {
            int original = 16711680;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianFourthByteIsOne()
        {
            int original = 16777216;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianFourthByteIsMax()
        {
            int original = -16777216;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianMinValue()
        {
            int original = int.MinValue;
            var bytes = new byte[] { 128, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt32BigEndianMaxValue()
        {
            int original = int.MaxValue;
            var bytes = new byte[] { 127, 255, 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt32(bytes, 0);
            Assert.AreEqual(original, result);
        }
    }
}
