namespace Bits
{
    using System;

    public class BitConverter
    {
        public readonly bool IsLittleEndian;

        public BitConverter()
            : this(true)
        {
        }

        public BitConverter(bool IsLittleEndian)
        {
            this.IsLittleEndian = IsLittleEndian;
        }

        public long DoubleToInt64Bits(double value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(bool value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(char value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(short value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(int value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(long value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(ushort value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(uint value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(ulong value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(float value)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes(double value)
        {
            throw new NotImplementedException();
        }

        public double Int64BitsToDouble(long value)
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(byte[] value, int startIndex)
        {
            throw new NotImplementedException();
        }

        public char ToChar(byte[] value, int startIndex)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(byte[] value, int startIndex)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(byte[] value, int startIndex)
        {
            if (this.IsLittleEndian)
            {
                return (short) (value[startIndex] | (value[startIndex + 1] << 8));
            }

            return (short)(value[startIndex] << 8 | (value[startIndex + 1]));
        }

        public int ToInt32(byte[] value, int startIndex)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(byte[] value, int startIndex)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(byte[] value, int startIndex)
        {
            if (this.IsLittleEndian)
            {
                return (ushort)(value[startIndex] | value[startIndex + 1]);
            }

            return (ushort)(value[startIndex + 1] | value[startIndex]);
        }

        public uint ToUInt32(byte[] value, int startIndex)
        {
            if (this.IsLittleEndian)
            {
                return (uint)(value[startIndex] | value[startIndex + 1]
                    | value[startIndex + 2] | value[startIndex + 3]);
            }

            return (uint)(value[startIndex + 3] | value[startIndex + 2]
                | value[startIndex + 1] | value[startIndex]);
        }

        public ulong ToUInt64(byte[] value, int startIndex)
        {
            if (this.IsLittleEndian)
            {
                return (uint)(value[startIndex] | value[startIndex + 1]
                    | value[startIndex + 2] | value[startIndex + 3]
                    | value[startIndex + 4] | value[startIndex + 5]
                    | value[startIndex + 6] | value[startIndex + 7]);
            }

            return (uint)(value[startIndex + 7] | value[startIndex + 6]
                | value[startIndex + 5] | value[startIndex + 4]
                | value[startIndex + 3] | value[startIndex + 2]
                | value[startIndex + 1] | value[startIndex]);
        }
    }
}
