using System.Diagnostics.Contracts;

namespace NetworkTime
{
    public class ByteConverter
    {
        public readonly bool IsLittleEndian;

        public ByteConverter()
            : this(true)
        {
        }

        public ByteConverter(bool isLittleEndian)
        {
            this.IsLittleEndian = isLittleEndian;
        }

        public byte[] GetBytes(short value)
        {
            var bytes = new byte[2];

            if (this.IsLittleEndian)
            {
                bytes[0] = (byte)(value & byte.MaxValue);
                bytes[1] = (byte)((value >> 8) & byte.MaxValue);
                return bytes;
            }

            bytes[1] = (byte)(value & byte.MaxValue);
            bytes[0] = (byte)((value >> 8) & byte.MaxValue);
            return bytes;
        }

        public byte[] GetBytes(int value)
        {
            var bytes = new byte[4];

            if (this.IsLittleEndian)
            {
                bytes[0] = (byte)(value & byte.MaxValue);
                bytes[1] = (byte)((value >> 8) & byte.MaxValue);
                bytes[2] = (byte)((value >> 16) & byte.MaxValue);
                bytes[3] = (byte)((value >> 24) & byte.MaxValue);
                return bytes;
            }

            bytes[3] = (byte)(value & byte.MaxValue);
            bytes[2] = (byte)((value >> 8) & byte.MaxValue);
            bytes[1] = (byte)((value >> 16) & byte.MaxValue);
            bytes[0] = (byte)((value >> 24) & byte.MaxValue);
            return bytes;
        }

        public byte[] GetBytes(long value)
        {
            var bytes = new byte[8];

            if (this.IsLittleEndian)
            {
                bytes[0] = (byte)(value & byte.MaxValue);
                bytes[1] = (byte)((value >> 8) & byte.MaxValue);
                bytes[2] = (byte)((value >> 16) & byte.MaxValue);
                bytes[3] = (byte)((value >> 24) & byte.MaxValue);
                bytes[4] = (byte)((value >> 32) & byte.MaxValue);
                bytes[5] = (byte)((value >> 40) & byte.MaxValue);
                bytes[6] = (byte)((value >> 48) & byte.MaxValue);
                bytes[7] = (byte)((value >> 56) & byte.MaxValue);

                return bytes;
            }

            bytes[7] = (byte)(value & byte.MaxValue);
            bytes[6] = (byte)((value >> 8) & byte.MaxValue);
            bytes[5] = (byte)((value >> 16) & byte.MaxValue);
            bytes[4] = (byte)((value >> 24) & byte.MaxValue);
            bytes[3] = (byte)((value >> 32) & byte.MaxValue);
            bytes[2] = (byte)((value >> 40) & byte.MaxValue);
            bytes[1] = (byte)((value >> 48) & byte.MaxValue);
            bytes[0] = (byte)((value >> 56) & byte.MaxValue);

            return bytes;
        }

        public byte[] GetBytes(ushort value)
        {
            return this.GetBytes((short)value);
        }

        public byte[] GetBytes(uint value)
        {
            return this.GetBytes((int)value);
        }

        public byte[] GetBytes(ulong value)
        {
            return this.GetBytes((long)value);
        }

        public short ToInt16(byte[] value, int startIndex)
        {
            Contract.Assert(value != null, "value cannot be null");
            Contract.Assert(startIndex <= value.Length - 2, "startIndex is out of bounds of the array");

            if (this.IsLittleEndian)
            {
                return (short)(value[startIndex] | value[startIndex + 1] << 8);
            }

            return (short)(value[startIndex] << 8 | value[startIndex + 1]);
        }

        public int ToInt32(byte[] value, int startIndex)
        {
            Contract.Assert(value != null, "value cannot be null");
            Contract.Assert(startIndex <= value.Length - 4, "startIndex is out of bounds of the array");

            if (this.IsLittleEndian)
            {
                return value[startIndex]
                    | (int)value[startIndex + 1] << 8
                    | (int)value[startIndex + 2] << 16
                    | (int)value[startIndex + 3] << 24;
            }

            return (int)value[startIndex] << 24
                | (int)value[startIndex + 1] << 16
                | (int)value[startIndex + 2] << 8
                | (int)value[startIndex + 3];
        }

        public long ToInt64(byte[] value, int startIndex)
        {
            Contract.Assert(value != null, "value cannot be null");
            Contract.Assert(startIndex <= value.Length - 8, "startIndex is out of bounds of the array");

            if (this.IsLittleEndian)
            {
                return (long)value[startIndex]
                    | (long)value[startIndex + 1] << 8
                    | (long)value[startIndex + 2] << 16
                    | (long)value[startIndex + 3] << 24
                    | (long)value[startIndex + 4] << 32
                    | (long)value[startIndex + 5] << 40
                    | (long)value[startIndex + 6] << 48
                    | (long)value[startIndex + 7] << 56;
            }

            return (long)value[startIndex] << 56
                | (long)value[startIndex + 1] << 48
                | (long)value[startIndex + 2] << 40
                | (long)value[startIndex + 3] << 32
                | (long)value[startIndex + 4] << 24
                | (long)value[startIndex + 5] << 16
                | (long)value[startIndex + 6] << 8
                | (long)value[startIndex + 7];
        }

        public ushort ToUInt16(byte[] value, int startIndex)
        {
            return (ushort)this.ToInt16(value, startIndex);
        }

        public uint ToUInt32(byte[] value, int startIndex)
        {
            return (uint)this.ToInt32(value, startIndex);
        }

        public ulong ToUInt64(byte[] value, int startIndex)
        {
            return (ulong)this.ToInt64(value, startIndex);
        }
    }
}
