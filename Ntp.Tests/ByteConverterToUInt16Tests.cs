namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterToUInt16Tests
    {
        [TestMethod]
        public void ToUInt16LittleEndianLesserByteIsOne()
        {
            ushort original = 1;
            var bytes = new byte[] { 1, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16LittleEndianLesserByteIsMax()
        {
            ushort original = 255;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16LittleEndianSecondByteIsOne()
        {
            ushort original = 256;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16LittleEndianSecondByteIsMax()
        {
            ushort original = 65280;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16LittleEndianMinValue()
        {
            ushort original = ushort.MinValue;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16LittleEndianMaxValue()
        {
            ushort original = ushort.MaxValue;
            var bytes = new byte[] { 255, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16BigEndianLesserByteIsOne()
        {
            ushort original = 1;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16BigEndianLesserByteIsMax()
        {
            ushort original = 255;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16BigEndianSecondByteIsOne()
        {
            ushort original = 256;
            var bytes = new byte[] { 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16BigEndianSecondByteIsMax()
        {
            ushort original = 65280;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16BigEndianMinValue()
        {
            ushort original = ushort.MinValue;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }

        [TestMethod]
        public void ToUInt16BigEndianMaxValue()
        {
            ushort original = ushort.MaxValue;
            var bytes = new byte[] { 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.ToUInt16(bytes, 0);
            Assert.AreEqual(original, result);
        }
    }
}
