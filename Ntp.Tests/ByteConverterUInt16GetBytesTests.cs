namespace NetworkTime.Ntp.Tests
{
    //using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NetworkTime;
    using NUnit.Framework;
    using TestClassAttribute = NUnit.Framework.TestFixtureAttribute;
    using TestMethodAttribute = NUnit.Framework.TestAttribute;

    [TestClass]
    public class ByteConverterUInt16GetBytesTests
    {
        [TestMethod]
        public void UInt16GetBytesLittleEndianLesserByteIsOne()
        {
            ushort original = 1;
            var bytes = new byte[] { 1, 0, };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesLittleEndianLesserByteIsMax()
        {
            ushort original = 255;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesLittleEndianSecondByteIsOne()
        {
            ushort original = 256;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesLittleEndianSecondByteIsMax()
        {
            ushort original = 65280;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesLittleEndianMinValue()
        {
            ushort original = ushort.MinValue;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesLittleEndianMaxValue()
        {
            ushort original = ushort.MaxValue;
            var bytes = new byte[] { 255, 255 };

            var bitConverter = new ByteConverter();
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesBigEndianLesserByteIsOne()
        {
            ushort original = 1;
            var bytes = new byte[] { 0, 1 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesBigEndianLesserByteIsMax()
        {
            ushort original = 255;
            var bytes = new byte[] { 0, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesBigEndianSecondByteIsOne()
        {
            ushort original = 256;
            var bytes = new byte[] { 1, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesBigEndianSecondByteIsMax()
        {
            ushort original = 65280;
            var bytes = new byte[] { 255, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesBigEndianMinValue()
        {
            ushort original = ushort.MinValue;
            var bytes = new byte[] { 0, 0 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        public void UInt16GetBytesBigEndianMaxValue()
        {
            ushort original = ushort.MaxValue;
            var bytes = new byte[] { 255, 255 };

            var bitConverter = new ByteConverter(false);
            var result = bitConverter.GetBytes(original);
            CollectionAssert.AreEqual(bytes, result);
        }
    }
}
