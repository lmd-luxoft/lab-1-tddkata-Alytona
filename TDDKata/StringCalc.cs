// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections.Generic;

namespace TDDKata
{
    internal class StringCalc
    {
        char[] _delimiters = new char[] { ',', ' ', '\n' };

        internal int Sum (string v)
        {
            int sum = 0;

            if (v == null)
                throw new BadArgumentException();

            if (v.Trim().Length == 0)
                return 0;

            List<char> delimiters = new List<char>( 10 );

            int index = 0;
            if (v.StartsWith( "//" ))
            {
                delimiters.AddRange( _delimiters );
                index = 2;
                while (index < v.Length && !Char.IsDigit( v[index] )) {
                    delimiters.Add( v[index] );
                    index++;
                }
                if (index == 2)
                    throw new BadArgumentException();
            }

            string[] numbers = delimiters.Count > 0 ? v.Substring( index ).Split( delimiters.ToArray() ) : v.Split( _delimiters );
            foreach (string number in numbers) 
            {
                int numberValue = -1;
                if (!Int32.TryParse( number, out numberValue ))
                    throw new BadArgumentException();

                if (numberValue < 0)
                    throw new BadArgumentException();

                if (numberValue <= 1000)
                    sum += numberValue;
            }
            return sum;
        }
    }
}