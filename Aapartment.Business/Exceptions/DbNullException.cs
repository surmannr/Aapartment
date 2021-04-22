using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Exceptions
{
    public class DbNullException : Exception
    {
        public DbNullException() : base("Nincs ilyen elem az adatbázisban.")
        {
        }
    }
}
