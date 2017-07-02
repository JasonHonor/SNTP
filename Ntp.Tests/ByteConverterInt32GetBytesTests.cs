namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterInt32GetBytesTests
    {
        [TestMethod]
        public void Int32GetBytesLittleEndianLesserByteIsOne()
        {
            int original = 1;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianLesserByteIsMax()
        {
            int original = 255;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianSecondByteIsOne()
        {
            int original = 256;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianSecondByteIsMax()
        {
            int original = 65280;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianThirdByteIsOne()
        {
            int original = 65536;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianThirdByteIsMax()
        {
            int original = 16711680;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianFourthByteIsOne()
        {
            int original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianFourthByteIsMax()
        {
            int original = -16777216;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianMinValue()
        {
            int original = int.MinValue;
            var bytes = new byte[] { 0, 0, 0, 128 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesLittleEndianMaxValue()
        {
            int original = int.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 127 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianLesserByteIsOne()
        {
            int original = 1;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianLesserByteIsMax()
        {
            int original = 255;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianSecondByteIsOne()
        {
            int original = 256;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianSecondByteIsMax()
        {
            int original = 65280;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianThirdByteIsOne()
        {
            int original = 65536;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianThirdByteIsMax()
        {
            int original = 16711680;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianFourthByteIsOne()
        {
            int original = 16777216;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianFourthByteIsMax()
        {
            int original = -16777216;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianMinValue()
        {
            int original = int.MinValue;
            var bytes = new byte[] { 128, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int32GetBytesBigEndianMaxValue()
        {
            int original = int.MaxValue;
            var bytes = new byte[] { 127, 255, 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }
    }
}
