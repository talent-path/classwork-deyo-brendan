using System;
using System.Collections.Generic;
using VendingMachine.Exceptions;
using VendingMachine.Models;
using VendingMachine.Persistence;
using VendingMachine.Services;

namespace VendingMachine.View
{
    public class VendingMachineView
    {
        //VendingMachineService _service;

        public VendingMachineView()
        {

        }

        //public decimal GetUserMoney()
        //{
        //    decimal toReturn = 0;

        //    Console.Write("Please enter a money amount for user: ");
        //    string toParse = Console.ReadLine();

        //    bool canParse = false;

        //    while(!canParse)
        //    {
        //        canParse = decimal.TryParse(toParse, out toReturn);
        //    }

        //    return toReturn;
        //}

        //public Change GetUserMoneyChange(decimal money)
        //{
        //    int[] toChange = _service.CalculateReturnChange(money);

        //    Change toReturn = new Change(toChange[0], toChange[1], toChange[2], toChange[3], toChange[4]);

        //    return toReturn;
        //}

        public string ShowAllVendingItems(List<VendingMachineItem> items)
        {
            // DISPLAY GOES HERE

            Console.WriteLine("****OVERLORD BRENDAN'S VENDING MACHINE***");
            Console.WriteLine("*********LIST OF AVAILABLE ITEMS*********");

            Console.WriteLine();

            string printItemList = "";

            foreach(VendingMachineItem item in items)
            {
                printItemList += "Choose " + item.Name + " by name to purchase. " + item.Quantity + " available";
                printItemList += Environment.NewLine;
            }

            Console.WriteLine(printItemList);

            Console.WriteLine();

            Console.WriteLine("*****************************************");

            Console.WriteLine();

            bool canBuy = false;

            string toReturn = "";

            while (!canBuy)
            {
                Console.Write("Enter item name to purchase: ");
                toReturn = Console.ReadLine();

                for(int i = 0; i < items.Count; i++)
                {
                    if (items[i].Name == toReturn && items[i].Quantity > 0)
                        canBuy = true;
                }

                if (!canBuy)
                    throw new ItemDoesNotExistException("Cannot buy item that is depleted or non existent.");
            }

            return toReturn;
        }

    }
}
