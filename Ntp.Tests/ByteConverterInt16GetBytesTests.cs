namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterInt16GetBytesTests
    {
        [TestMethod]
        public void Int16GetBytesLittleEndianLesserByteIsOne()
        {
            short original = 1;
            var bytes = new byte[] { 1, 0, };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesLittleEndianLesserByteIsMax()
        {
            short original = 255;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesLittleEndianSecondByteIsOne()
        {
            short original = 256;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesLittleEndianSecondByteIsMax()
        {
            short original = -256;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void ToInt16LittleEndianZero()
        {
            short original = 0;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesLittleEndianMinValue()
        {
            short original = short.MinValue;
            var bytes = new byte[] { 0, 128 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesLittleEndianMaxValue()
        {
            short original = short.MaxValue;
            var bytes = new byte[] { 255, 127 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesBigEndianLesserByteIsOne()
        {
            short original = 1;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesBigEndianLesserByteIsMax()
        {
            short original = 255;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesBigEndianSecondByteIsOne()
        {
            short original = 256;
            var bytes = new byte[] { 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void ToInt16BigEndianZero()
        {
            short original = 0;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesBigEndianSecondByteIsMax()
        {
            short original = -256;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesBigEndianMinValue()
        {
            short original = short.MinValue;
            var bytes = new byte[] { 128, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void Int16GetBytesBigEndianMaxValue()
        {
            short original = short.MaxValue;
            var bytes = new byte[] { 127, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }
    }
}
