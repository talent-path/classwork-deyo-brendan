using System;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachineDao
    {
        public void RemoveItemQty(VendingMachineItem item);

        public List<VendingMachineItem> GetAllVMItems();
    }
}
