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
            Description = "Positive round number")]
        [TestCase(122.625,
            ExpectedResult = "0100000001011110101010000000000000000000000000000000000000000000",
            Description = "Value with good fraction (power of 5)")]
        [Test]
        public string DoubleToBinaryString(double value)
        {
            return value.DoubleToBinaryString();
        }
    }
}
