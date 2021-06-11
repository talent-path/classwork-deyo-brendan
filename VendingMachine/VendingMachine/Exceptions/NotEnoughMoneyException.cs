using System;
namespace VendingMachine.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string message) : base(message)
        {

        }

        public NotEnoughMoneyException(string message, Exception e) : base(message, e)
        {

        }
    }
}
