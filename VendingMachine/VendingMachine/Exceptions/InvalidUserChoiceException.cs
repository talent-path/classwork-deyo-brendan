using System;
namespace VendingMachine.Exceptions
{
    public class InvalidUserChoiceException : Exception
    {
        public InvalidUserChoiceException(string message) : base(message) 
        {

        }

        public InvalidUserChoiceException(string message, Exception e) : base(message, e)
        {

        }
    }
}
