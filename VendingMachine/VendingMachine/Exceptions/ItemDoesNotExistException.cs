using System;
namespace VendingMachine.Exceptions
{
    public class ItemDoesNotExistException : Exception
    {
        public ItemDoesNotExistException(string message) : base(message)
        {

        }

        public ItemDoesNotExistException(string message, Exception e) : base(message, e)
        {

        }
    }
}
