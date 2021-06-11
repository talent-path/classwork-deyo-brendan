using System;
using System.Collections.Generic;
using VendingMachine.Exceptions;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class VendingMachineService : IVendingMachineService
    {

        IVendingMachineDao _dao;

        public VendingMachineService()
        {

        }

        public void BuyItem(VendingMachineItem item, double userMoney)
        {
            if (userMoney >= item.Price)
            {
                if (item.Quantity > 0)
                {
                    userMoney -= item.Price;
                    _dao.RemoveItemQty(item);
                }
                else
                {
                    throw new ItemDepletedException("The item you have chosen is no longer available.");
                }
            }
            else
                throw new NotEnoughMoneyException("You need more money to purchase this item.");
        }

        public List<VendingMachineItem> GetAllVendingMachineItems()
        {
            List<VendingMachineItem> toReturn = _dao.GetAllVMItems();
            return toReturn;
        }
    }
}
