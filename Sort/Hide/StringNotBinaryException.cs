﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideConverting
{
    public class StringNotBinaryException : Exception
    {
        public StringNotBinaryException() { }
        public StringNotBinaryException(string _message) : base (_message) { }
    }
}
