using System;
namespace VendingMachine.Exceptions
{
    public class NullItemPropertyException : Exception
    {
        public NullItemPropertyException(string message) : base(message)
        {

        }

        public NullItemPropertyException(string message, Exception e) : base(message, e)
        {

        }

    }
}
