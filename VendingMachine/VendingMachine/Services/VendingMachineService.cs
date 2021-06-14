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

        public VendingMachineService(IVendingMachineDao dao)
        {
            _dao = dao;
        }


        // output a change obj
        public Change BuyItem(VendingMachineItem item, decimal userMoney)
        {
            Change toReturn = new Change();

            if (userMoney < 0)
                throw new InvalidUserMoneyException("User does not have any money");

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

            // convert amount of change to int then subtract from user money each time

            int numOfDollars = (int)(userMoney / UserMoney.Dollar);
            userMoney = userMoney - (numOfDollars * UserMoney.Dollar);

            int numOfQuarters = (int)(userMoney / UserMoney.Quarter);
            userMoney = userMoney - (numOfQuarters * UserMoney.Quarter);

            int numOfDimes = (int)(userMoney / UserMoney.Dime);
            userMoney = userMoney - (numOfDimes * UserMoney.Dime);

            int numOfNickels = (int)(userMoney / UserMoney.Nickel);
            userMoney = userMoney - (numOfNickels * UserMoney.Nickel);

            int numOfPennies = (int)(userMoney / UserMoney.Penny);

            toReturn = new Change(numOfDollars, numOfQuarters, numOfDimes, numOfNickels, numOfPennies);

            return toReturn;
        }

        public List<VendingMachineItem> GetAllVendingMachineItems()
        {
            List<VendingMachineItem> toReturn = _dao.GetAllVMItems();

            if (toReturn.Count <= 0)
                throw new VendingMachineEmptyException("There are no more items in this vending machine");

            return toReturn;
        }
    }
}
