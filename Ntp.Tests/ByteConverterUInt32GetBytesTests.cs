namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterUInt32GetBytesTests
    {
        [TestMethod]
        public void UInt32GetBytesLittleEndianLesserByteIsOne()
        {
            uint original = 1;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianLesserByteIsMax()
        {
            uint original = 255;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianSecondByteIsOne()
        {
            uint original = 256;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianSecondByteIsMax()
        {
            uint original = 65280;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianThirdByteIsOne()
        {
            uint original = 65536;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianThirdByteIsMax()
        {
            uint original = 16711680;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianFourthByteIsOne()
        {
            uint original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianFourthByteIsMax()
        {
            uint original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianMinValue()
        {
            uint original = uint.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesLittleEndianMaxValue()
        {
            uint original = uint.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianLesserByteIsOne()
        {
            uint original = 1;
            var bytes = new byte[] { 0, 0, 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianLesserByteIsMax()
        {
            uint original = 255;
            var bytes = new byte[] { 0, 0, 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianSecondByteIsOne()
        {
            uint original = 256;
            var bytes = new byte[] { 0, 0, 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianSecondByteIsMax()
        {
            uint original = 65280;
            var bytes = new byte[] { 0, 0, 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianThirdByteIsOne()
        {
            uint original = 65536;
            var bytes = new byte[] { 0, 1, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianThirdByteIsMax()
        {
            uint original = 16711680;
            var bytes = new byte[] { 0, 255, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianFourthByteIsOne()
        {
            uint original = 16777216;
            var bytes = new byte[] { 1, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianFourthByteIsMax()
        {
            uint original = 4278190080;
            var bytes = new byte[] { 255, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianMinValue()
        {
            uint original = uint.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt32GetBytesBigEndianMaxValue()
        {
            uint original = uint.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }
    }
}
