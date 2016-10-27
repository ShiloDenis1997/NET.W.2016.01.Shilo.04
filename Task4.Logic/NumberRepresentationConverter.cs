using System.Runtime.InteropServices;
using System.Text;

namespace Task4.Logic
{
    public static class NumberRepresentationConverter
    {
        /// <summary>
        /// Makes string representation of bits of doubel value x according
        /// to IEEE754 standart
        /// </summary>
        /// <param name="x"></param>
        /// <returns>String representation of bits</returns>
        public static string DoubleToBinaryString(this double x)
        {
            var convertStruct = 
                new DoubleToLongStruct {DoubleBitsRepresentation = x};
            long value = convertStruct.LongBitsRepresentation;
            var sb = new StringBuilder(64);
            sb.Append(value < 0 ? '1' : '0');
            for (int i = 62; i >= 0; i--)
            {
                sb.Append((value & (1 << i)) != 0 ? '1' : '0');
            }
            return sb.ToString();
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
