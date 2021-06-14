using System;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachineDao
    {
        public List<VendingMachineItem> GetAllVMItems();

        public void RemoveItemQty(VendingMachineItem item);

        public VendingMachineItem GetItemByName(string name);
    }
}
