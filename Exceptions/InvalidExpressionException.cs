using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib.Exceptions
{
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException(string message) : base(message) { }

        public InvalidExpressionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
