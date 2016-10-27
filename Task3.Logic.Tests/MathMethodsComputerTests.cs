using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnitExtension;

namespace Task3.Logic.Tests
{
    [TestFixture]
    public class MathMethodsComputerTests
    {
        [TestCase(9, 2, 1e-10, 3.0000000000,
            Description = "Test sqrt.")]
        [TestCase(15, 3, 1e-6, 2.466212,
            Description = "Power = 3")]
        [TestCase(1, 15, 1e-6, 1.000000,
            Description = "Test sqrtn from one")]
        [TestCase(0, 10, 1e-8, 0,
            Description = "Test sqrtn from zero")]
        [TestCase(5, 1, 1e-6, 5,
            Description = "Test power = 1")]
        [TestCase(25489, 9, 1e-6, 3.087413,
            Description = "Test big power root from big value")]
        [TestCase(0.3, 10, 1e-10, 0.8865681505,
            Description = "Less than 1 value, big power test, and little epsilon test")]
        [Test]
        public void Sqrtn_ValueEpsilon_RootOfDegreeNReturn
            (double value, int power, double epsilon, double expected)
        {
            //act
            double actual = value.Sqrtn(power, epsilon);
            //assert
            Assert.LessOrEqual(Math.Abs(actual - expected), epsilon);
        }
    }
}
