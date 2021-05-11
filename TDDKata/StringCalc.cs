// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace TDDKata
{
    internal class StringCalc
    {
        char[] _delimiters = new char[] { ',', ' ' };

        internal int Sum(string v)
        {
            int sum = 0;

            if (v == null)
                return -1;

            if (v.Trim().Length == 0)
                return 0;

            string[] numbers = v.Split( _delimiters );
            if (numbers.Length > 2)
                return -1;

            foreach (string number in numbers) 
            {
                int numberValue = -1;
                if (!Int32.TryParse( number, out numberValue ))
                    return -1;

                if (numberValue < 0)
                    return -1;

                sum += numberValue;
            }
            return sum;
        }
    }
}