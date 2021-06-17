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

        public string ShowAllVendingItems(List<VendingMachineItem> items)
        {
            // DISPLAY GOES HERE

            Console.WriteLine();

            Console.WriteLine("****OVERLORD BRENDAN'S VENDING MACHINE***");
            Console.WriteLine("*********LIST OF AVAILABLE ITEMS*********");

            Console.WriteLine();

            string printItemList = "";

            foreach(VendingMachineItem item in items)
            {
                printItemList += "Choose " + item.Name + " by name to purchase | " + item.Quantity + " available. ";
                printItemList += "Price: $" + item.Price;
                printItemList += Environment.NewLine;
            }

            Console.WriteLine(printItemList);

            Console.WriteLine();

            Console.WriteLine("*****************************************");

            Console.WriteLine();

            bool canBuy = false;

            bool itemExists = false;

            bool printError = true;

            string toReturn = "";

            while (!canBuy && !itemExists)
            {
                Console.Write("Enter item name to purchase: ");
                toReturn = Console.ReadLine();

                for(int i = 0; i < items.Count; i++)
                {
                    if (items[i].Name == toReturn && items[i].Quantity > 0)
                    {
                        itemExists = true;
                        canBuy = true;
                        printError = false;
                    }
                }

                if (!canBuy && !itemExists && printError)
                    Console.WriteLine("Item is depleted. Pick another!");
            }

            return toReturn;
        }

    }
}
