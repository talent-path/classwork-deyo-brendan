using System;
using System.Collections.Generic;
using VendingMachine.Interfaces;

namespace VendingMachine.Models
{
    public class VendingMachineObject : IVendingMachineObject
    {
        public List<VendingMachineItem> Items { get; set; }

        public VendingMachineObject()
        {

        }

        public VendingMachineObject(List<VendingMachineItem> items)
        {
            Items = items;
        }

        public VendingMachineObject(VendingMachineObject that)
        {
            Items = new List<VendingMachineItem>();
            for (int i = 0; i < that.Items.Count; i++)
                Items[i] = that.Items[i];
        }
    }
}
