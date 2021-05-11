// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace TDDKata
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void SimpleTest()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum("2,2");
            Assert.That(value, Is.EqualTo(4), "Wrong actual value");
        }

        [Test]
        public void SumNull ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( null );

            Assert.That( value, Is.EqualTo( -1 ), "Wrong actual value" );
        }

        [Test]
        public void SumEmpty ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "" );

            Assert.That( value, Is.EqualTo( 0 ), "Wrong actual value" );
        }

        [Test]
        public void SumSpaces ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "  " );

            Assert.That( value, Is.EqualTo( 0 ), "Wrong actual value" );
        }

        [Test]
        public void SumOneCorrect ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1" );

            Assert.That( value, Is.EqualTo( 1 ), "Wrong actual value" );
        }
        [Test]
        public void SumOneNegative ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "-5" );

            Assert.That( value, Is.EqualTo( -1 ), "Wrong actual value" );
        }
        [Test]
        public void SumOneNoNumber ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "ABC" );

            Assert.That( value, Is.EqualTo( -1 ), "Wrong actual value" );
        }
        [Test]
        public void SumTwoCorrect ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1,2" );

            Assert.That( value, Is.EqualTo( 3 ), "Wrong actual value" );
        }
        [Test]
        public void SumTwoCorrectManyDigits ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "12323,24444" );

            Assert.That( value, Is.EqualTo( 12323 + 24444 ), "Wrong actual value" );
        }
        [Test]
        public void SumTwoIncorrectDelimiter ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1 2" );

            Assert.That( value, Is.EqualTo( 3 ), "Wrong actual value" );
        }
        [Test]
        public void SumTwoFirstNegative ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "-1,2" );

            Assert.That( value, Is.EqualTo( -1 ), "Wrong actual value" );
        }
        [Test]
        public void SumTwoSecondNegative ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1,-2" );

            Assert.That( value, Is.EqualTo( -1 ), "Wrong actual value" );
        }
        [Test]
        public void SumThreeNumbers ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1,2,3" );

            Assert.That( value, Is.EqualTo( -1 ), "Wrong actual value" );
        }
        [Test]
        public void SumFourNumbers ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1,2,3,4" );

            Assert.That( value, Is.EqualTo( -1 ), "Wrong actual value" );
        }
    }
}
