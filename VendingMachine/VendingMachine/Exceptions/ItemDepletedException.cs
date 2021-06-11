using System;
namespace VendingMachine.Exceptions
{
    public class ItemDepletedException : Exception
    {
        public ItemDepletedException(string message) : base(message)
        {

        }

        public ItemDepletedException(string message, Exception e) : base(message, e)
        {

        }
    }
}
