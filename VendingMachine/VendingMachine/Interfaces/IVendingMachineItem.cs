using System;
namespace VendingMachine.Interfaces
{
    public interface IVendingMachineItem
    {
        public int Quantity { get; }
        public decimal Price { get; }
        public string Name { get;  }
        public string Category { get; }
    }
}
