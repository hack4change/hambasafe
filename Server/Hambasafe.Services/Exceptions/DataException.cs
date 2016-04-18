using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hambasafe.Services.Exceptions
{
    public class DataException : Exception
    {
        public DataException()
        {
        }

        public DataException(string message)
            : base(message)
        {
        }

        public DataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
