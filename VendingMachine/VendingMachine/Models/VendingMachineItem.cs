using System;
using VendingMachine.Interfaces;

namespace VendingMachine.Models
{
    public class VendingMachineItem : IVendingMachineItem
    {
        public VendingMachineItem()
        {


        }

        public VendingMachineItem(int quantity, decimal price,
            string name, string category)
        {
            Quantity = quantity;
            Price = price;
            Name = name;
            Category = category;
        }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }
    }


    //TODO create a to string override method that prints items to file nicely
}
