using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Exceptions
{
    public class QueryParamsNullException : Exception
    {
        public QueryParamsNullException() : base("A megadott paraméterek nem érvényesek az adott lekérdezésre.")
        {
        }

        public QueryParamsNullException(string message) : base(message)
        {
        }
    }
}
