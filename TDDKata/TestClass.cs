// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
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
            Assert.Throws<BadArgumentException>( () => calc.Sum( null ) );
        }

        [Test]
        public void SumEmpty ()
        {
            StringCalc calc = new StringCalc();
            Assert.That( calc.Sum( "" ), Is.EqualTo( 0 ), "Wrong actual value" );
        }

        [Test]
        public void SumSpaces ()
        {
            StringCalc calc = new StringCalc();
            Assert.That( calc.Sum( "  " ), Is.EqualTo( 0 ), "Wrong actual value" );
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
            Assert.Throws<BadArgumentException>( () => calc.Sum( "-5" ) );
        }
        [Test]
        public void SumOneNoNumber ()
        {
            StringCalc calc = new StringCalc();
            Assert.Throws<BadArgumentException>( () => calc.Sum( "ABC" ) );
        }
        [Test]
        public void SumTwoCorrect ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1,2" );

            Assert.That( value, Is.EqualTo( 3 ), "Wrong actual value" );
        }
        [Test]
        public void SumTwoCorrectWithCrlf ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1\n2" );

            Assert.That( value, Is.EqualTo( 3 ), "Wrong actual value" );
        }
        [Test]
        public void SumTwoCorrectManyDigits ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "12323,24444" );

            Assert.That( value, Is.EqualTo( 0 ), "Wrong actual value" );
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
            Assert.Throws<BadArgumentException>( () => calc.Sum( "-1,2" ) );
        }
        [Test]
        public void SumTwoSecondNegative ()
        {
            StringCalc calc = new StringCalc();
            Assert.Throws<BadArgumentException>( () => calc.Sum( "1,-2" ) );
        }
        [Test]
        public void SumThreeNumbers ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1,2\n3" );

            Assert.That( value, Is.EqualTo( 6 ), "Wrong actual value" );
        }
        [Test]
        public void SumFourNumbers ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1,2\n3,4" );

            Assert.That( value, Is.EqualTo( 10 ), "Wrong actual value" );
        }
        [Test]
        public void SumWithCustomDelimiterPoint ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "//.1\n2.3" );

            Assert.That( value, Is.EqualTo( 6 ), "Wrong actual value" );
        }
        [Test]
        public void SumWithCustomDelimiters ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "//.#1,2.3#4" );

            Assert.That( value, Is.EqualTo( 10 ), "Wrong actual value" );
        }
        [Test]
        public void SumWithNoCustomDelimiters ()
        {
            StringCalc calc = new StringCalc();
            Assert.Throws<BadArgumentException>( () => calc.Sum( "//1,2" ) );
        }
        [Test]
        public void SumWithCustomDelimitersNotFromLeft ()
        {
            StringCalc calc = new StringCalc();
            Assert.Throws<BadArgumentException>( () => calc.Sum( " //.1.2" ) );
        }
        [Test]
        public void SumThousandOne ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1000" );

            Assert.That( value, Is.EqualTo( 1000 ), "Wrong actual value" );
        }
        [Test]
        public void SumBigNumberOne ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1001" );

            Assert.That( value, Is.EqualTo( 0 ), "Wrong actual value" );
        }
        [Test]
        public void SumBigNumberTwoFirst ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "1001,55" );

            Assert.That( value, Is.EqualTo( 55 ), "Wrong actual value" );
        }
        [Test]
        public void SumBigNumberTwoSecond ()
        {
            StringCalc calc = new StringCalc();
            int value = calc.Sum( "77,1001" );

            Assert.That( value, Is.EqualTo( 77 ), "Wrong actual value" );
        }
    }
}
