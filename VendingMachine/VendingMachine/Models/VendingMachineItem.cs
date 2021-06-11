using System;
using VendingMachine.Interfaces;

namespace VendingMachine.Models
{
    public class VendingMachineItem : IVendingMachineItem
    {
        public VendingMachineItem()
        {


        }

        public VendingMachineItem(int quantity, double price,
            string name, string category)
        {
            Quantity = quantity;
            Price = price;
            Name = name;
            Category = category;
        }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }
    }
}
