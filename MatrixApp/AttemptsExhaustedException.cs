using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class AttemptsExhaustedException : Exception
    {
        public AttemptsExhaustedException (string message) 
            : base(message) { }
    }
}