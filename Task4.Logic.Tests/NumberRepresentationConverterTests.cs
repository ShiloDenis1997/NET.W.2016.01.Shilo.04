using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Task4.Logic.Tests
{
    [TestFixture]
    public class NumberRepresentationConverterTests
    {
        [TestCase(155,
            ExpectedResult = "0100000001100011011000000000000000000000000000000000000000000000",
            Description = "Positive round value")]
        [TestCase(122.625,
            ExpectedResult = "0100000001011110101010000000000000000000000000000000000000000000",
            Description = "Positive value with good fraction (power of 5)")]
        [TestCase(451387.2345,
            ExpectedResult = "0100000100011011100011001110110011110000001000001100010010011100",
            Description = "Posititve value with bad fraction (not power of 5)")]
        [TestCase(-155,
            ExpectedResult = "1100000001100011011000000000000000000000000000000000000000000000",
            Description = "Negative round value")]
        [TestCase(-122.625,
            ExpectedResult = "1100000001011110101010000000000000000000000000000000000000000000",
            Description = "Negative value with good fraction (power of 5)")]
        [TestCase(-451387.2345,
            ExpectedResult = "1100000100011011100011001110110011110000001000001100010010011100",
            Description = "Negative value with vad fraction (not power of 5)")]
        [TestCase(double.NaN,
            ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000",
            Description = "double NaN test. It's only a constant value."
                + " By fact NaN is every value > +inf or < -inf")]
        [TestCase(double.NegativeInfinity,
            ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000",
            Description = "double NegativeInfinity test")]
        [TestCase(double.PositiveInfinity,
            ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000",
            Description = "double PositiveInfinity test")]
        [TestCase(0.0,
            ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000",
            Description = "+0 test")]
        [TestCase(-0.0, 
            ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000",
            Description = "-0 test")]
        [Test]
        public string DoubleToBinaryString_Double_StringReturn(double value)
        {
            return value.DoubleToBinaryString();
        }
    }
}
