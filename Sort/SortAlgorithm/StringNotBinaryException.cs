using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    class StringNotBinaryException : Exception
    {
        public StringNotBinaryException() { }
        public StringNotBinaryException(string _message) : base (_message) { }
    }
}
