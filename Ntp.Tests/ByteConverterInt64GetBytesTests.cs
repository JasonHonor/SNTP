namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterInt64GetBytesTests
    {
        [TestMethod]
        public void Int64GetBytesLittleEndianLesserByteIsOne()
        {
            long original = 1;
            var bytes = new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianLesserByteIsMax()
        {
            long original = 255;
            var bytes = new byte[] { 255, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianSecondByteIsOne()
        {
            long original = 256;
            var bytes = new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianSecondByteIsMax()
        {
            long original = 65280;
            var bytes = new byte[] { 0, 255, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianThirdByteIsOne()
        {
            long original = 65536;
            var bytes = new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianThirdByteIsMax()
        {
            long original = 16711680;
            var bytes = new byte[] { 0, 0, 255, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianFourthByteIsOne()
        {
            long original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianFourthByteIsMax()
        {
            long original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 255, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianMinValue()
        {
            long original = long.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 128 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesLittleEndianMaxValue()
        {
            long original = long.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255, 255, 255, 255, 127 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianLesserByteIsOne()
        {
            long original = 1;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianLesserByteIsMax()
        {
            long original = 255;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianSecondByteIsOne()
        {
            long original = 256;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianSecondByteIsMax()
        {
            long original = 65280;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianThirdByteIsOne()
        {
            long original = 65536;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianThirdByteIsMax()
        {
            long original = 16711680;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 255, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianFourthByteIsOne()
        {
            long original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianFourthByteIsMax()
        {
            long original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 0, 255, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianMinValue()
        {
            long original = long.MinValue;
            var bytes = new byte[] { 128, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int64GetBytesBigEndianMaxValue()
        {
            long original = long.MaxValue;
            var bytes = new byte[] { 127, 255, 255, 255, 255, 255, 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }
    }
}
