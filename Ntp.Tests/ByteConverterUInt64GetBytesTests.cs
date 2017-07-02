namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterUInt64GetBytesTests
    {
        [TestMethod]
        public void UInt64GetBytesLittleEndianLesserByteIsOne()
        {
            ulong original = 1;
            var bytes = new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianLesserByteIsMax()
        {
            ulong original = 255;
            var bytes = new byte[] { 255, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianSecondByteIsOne()
        {
            ulong original = 256;
            var bytes = new byte[] { 0, 1, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianSecondByteIsMax()
        {
            ulong original = 65280;
            var bytes = new byte[] { 0, 255, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianThirdByteIsOne()
        {
            ulong original = 65536;
            var bytes = new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianThirdByteIsMax()
        {
            ulong original = 16711680;
            var bytes = new byte[] { 0, 0, 255, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianFourthByteIsOne()
        {
            ulong original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianFourthByteIsMax()
        {
            ulong original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 255, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianMinValue()
        {
            ulong original = ulong.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesLittleEndianMaxValue()
        {
            ulong original = ulong.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianLesserByteIsOne()
        {
            ulong original = 1;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianLesserByteIsMax()
        {
            ulong original = 255;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianSecondByteIsOne()
        {
            ulong original = 256;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianSecondByteIsMax()
        {
            ulong original = 65280;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianThirdByteIsOne()
        {
            ulong original = 65536;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 1, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianThirdByteIsMax()
        {
            ulong original = 16711680;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 255, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianFourthByteIsOne()
        {
            ulong original = 16777216;
            var bytes = new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianFourthByteIsMax()
        {
            ulong original = 4278190080;
            var bytes = new byte[] { 0, 0, 0, 0, 255, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianMinValue()
        {
            ulong original = ulong.MinValue;
            var bytes = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt64GetBytesBigEndianMaxValue()
        {
            ulong original = ulong.MaxValue;
            var bytes = new byte[] { 255, 255, 255, 255, 255, 255, 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }
    }
}
