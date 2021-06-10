using System;

namespace VendingMachine
{
    public class VendingMachineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }


        public VendingMachineItem()
        {

        }

        public VendingMachineItem(VendingMachineItem that)
        {
            this.Id = that.Id;
            this.Quantity = that.Quantity;
            this.Name = that.Name;
            this.Category = that.Category;
            this.Price = that.Price;
        }
    }
}