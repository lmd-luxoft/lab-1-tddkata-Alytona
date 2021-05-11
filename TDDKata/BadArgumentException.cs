// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace TDDKata
{
    public class BadArgumentException : ArgumentException
    {
        public BadArgumentException () : base() { 
        }
    }
}