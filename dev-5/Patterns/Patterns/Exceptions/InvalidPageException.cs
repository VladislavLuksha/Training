using System;

namespace Patterns.Exceptions
{
    public class InvalidPageException : Exception
    {
        public InvalidPageException(string message) : base(message) { }
    }
}
