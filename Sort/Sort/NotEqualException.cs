using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class NotEqualException : System.Exception
    {
        object objOne;
        object objTwo;
        int arrayPos;

        public NotEqualException(object _first, object _second, int _arrayPos)
        {
            objOne = _first;
            objTwo = _second;
            arrayPos = _arrayPos;
        }

        public override string Message
        {
            get
            {
                return "At array[" + arrayPos.ToString() + "], content " + objOne.ToString() + " and " + objTwo.ToString() + " are not equal.";
            }
        }
    }
}
