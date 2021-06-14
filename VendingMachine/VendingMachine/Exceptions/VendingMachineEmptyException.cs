using System;
namespace VendingMachine.Exceptions
{
    public class VendingMachineEmptyException : Exception
    {
        public VendingMachineEmptyException(string message) : base(message)
        {
        }

        public VendingMachineEmptyException(string message, Exception e) : base(message, e)
        {

        }
    }
}
