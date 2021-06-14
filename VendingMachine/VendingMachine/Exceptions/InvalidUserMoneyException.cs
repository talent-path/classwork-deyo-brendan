using System;
namespace VendingMachine.Exceptions
{
    public class InvalidUserMoneyException : Exception
    {
        public InvalidUserMoneyException(string message) : base(message)
        {

        }

        public InvalidUserMoneyException(string message, Exception e) : base(message, e)
        {

        }
    }
}
