using System;
namespace VendingMachine.Exceptions
{
    public class TransactionFailedException : Exception
    {
        public TransactionFailedException(string message) : base(message)
        {
        }

        public TransactionFailedException(string message, Exception e) : base(message, e)
        {

        }
    }
}
