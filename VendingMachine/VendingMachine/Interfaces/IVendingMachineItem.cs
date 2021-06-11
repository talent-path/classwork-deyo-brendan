using System;
namespace VendingMachine.Interfaces
{
    public interface IVendingMachineItem
    {
        public int Quantity { get; }
        public double Price { get; }
        public string Name { get;  }
        public string Category { get; }
    }
}
