using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestsNunit
{
    [TestFixture]
    public class Tests
    {
        [TestCase(2, 4, 16)]
        [TestCase(3, 2, 9)]
        [TestCase(4, 2, 16)]
        [TestCase(3, 3, 27)]
        [TestCase(3, 4, 81)]

        public void MathPow(double digit, double power, double resultExpected)
        {
            EmbeddedMethods func = new EmbeddedMethods();
            Assert.AreEqual(resultExpected, func.Pow(digit, power)); //classic model
            Assert.That(func.Pow(digit, power), Is.EqualTo(resultExpected)); //constraint model
        }

        [Test]
        public void Random() 
        { 
            var x = 4;
            var y=10;
            Assert.That(new Random().Next(x, y), Is.InRange(x, y)); //constraint model
        }

        [Test]
        public void StringConcat()
        {
            string str1 = "Hello";
            string str2 = " World";
            string result = str1 + str2;
            Assert.That(str1.Length + str2.Length, Is.EqualTo(result.Length));
            Assert.That(result, Does.StartWith(str1));
            Assert.That(result, Does.EndWith(str2));
        }

        [Test]
        public void Reverse()
        {
            string str = "any desired string";
            Assert.That(str.Reverse(), Is.EquivalentTo(str));
        }


    }
}
