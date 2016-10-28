using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Task4.Logic
{
    public static class NumberRepresentationConverter
    {
        /// <summary>
        /// Makes string representation of bits of double value 
        /// <paramref name="x"/> according
        /// to IEEE754 standart
        /// </summary>
        /// <param name="x"></param>
        /// <returns>String representation of bits</returns>
        public static string DoubleToBinaryString(this double x)
        {
            var convertStruct = 
                new DoubleToLongStruct {DoubleBitsRepresentation = x};
            long value = convertStruct.LongBitsRepresentation;
            int bitsCount = sizeof(double) * 8;
            char[] result = new char[bitsCount];
            result[0] = value < 0 ? '1' : '0';
            for (int i = bitsCount - 2, j = 1; i >= 0; i--, j++)
            {
                result[j] = (value & ((long)1 << i)) != 0 ? '1' : '0';
            }
            return new string(result);
        }

        /// <summary>
        /// Helps to easy convert double value bit mask to long value
        /// by overlapping fields
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;

            public long LongBitsRepresentation => long64bits;

            public double DoubleBitsRepresentation
            {
                set { double64bits = value; }
            }
        }
    }
}
