using System;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachineService
    {
        public List<VendingMachineItem> GetAllVendingMachineItems();

        public Change BuyItem(VendingMachineItem item, decimal userMoney);

    }
}
