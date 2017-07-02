namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterToInt16Tests
    {
        [TestMethod]
        public void ToInt16LittleEndianLesserByteIsOne()
        {
            short original = 1;
            var bytes = new byte[] { 1, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16LittleEndianLesserByteIsMax()
        {
            short original = 255;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16LittleEndianSecondByteIsOne()
        {
            short original = 256;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16LittleEndianSecondByteIsMax()
        {
            short original = -256;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16LittleEndianZero()
        {
            short original = 0;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16LittleEndianMinValue()
        {
            short original = short.MinValue;
            var bytes = new byte[] { 0, 128 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16LittleEndianMaxValue()
        {
            short original = short.MaxValue;
            var bytes = new byte[] { 255, 127 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16BigEndianLesserByteIsOne()
        {
            short original = 1;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16BigEndianLesserByteIsMax()
        {
            short original = 255;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16BigEndianSecondByteIsOne()
        {
            short original = 256;
            var bytes = new byte[] { 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16BigEndianSecondByteIsMax()
        {
            short original = -256;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16BigEndianZero()
        {
            short original = 0;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16BigEndianMinValue()
        {
            short original = short.MinValue;
            var bytes = new byte[] { 128, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToInt16BigEndianMaxValue()
        {
            short original = short.MaxValue;
            var bytes = new byte[] { 127, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }
    }
}
