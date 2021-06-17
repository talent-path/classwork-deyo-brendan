using System;
using System.Collections.Generic;
using VendingMachine.Services;
using VendingMachine.View;
using VendingMachine.Models;
using VendingMachine.Interfaces;
using VendingMachine.Persistence;
using VendingMachine.Exceptions;

namespace VendingMachine.Controllers
{
    public class VendingMachineController
    {
        // probably needs the service and view, going to call in Program.cs to run app

        VendingMachineService _service;
        VendingMachineView _view;

        ItemFileDao _fileDao =
           new ItemFileDao("/Users/brendandeyo/Desktop/classwork-deyo-brendan/VendingMachine/VendingMachine/ItemList.txt");

        public VendingMachineController(VendingMachineService service, VendingMachineView view)
        {
            _service = service;
            _view = view;
        }

        public decimal GetUserMoney()
        {
            decimal toReturn = 0;

            bool canParse = false;

            while (!canParse)
            {
                Console.Write("Please enter a money amount for user: ");
                string toParse = Console.ReadLine();

                canParse = decimal.TryParse(toParse, out toReturn);
            }

            return toReturn;
        }

        public void GetResponseMessage(VendingMachineItem item)
        {
            if (item.Category == "Candy")
            {
                Console.WriteLine("You have purchased a: " + item.Name + "..... MMMMMMM, YUMMY");
                Console.WriteLine();
            }
            else if (item.Category == "Chips")
            {
                Console.WriteLine("You have purchased a bag of: " + item.Name + "..... MMMMMMM, CRUNCHY");
                Console.WriteLine();
            }
            else if (item.Category == "Soda")
            {
                Console.WriteLine("You have purchased a bottle of: " + item.Name + "..... OOOOO, REFRESHING");
                Console.WriteLine();
            }
            else
                throw new ItemDoesNotExistException("I'm confused, this should not be possible");
        }

        public void StartVendingMachineApp()
        {
            bool finished = false;

            while (!finished)
            {
                decimal userMoney = GetUserMoney();

                List<VendingMachineItem> items = _fileDao.GetAllVMItems();

                string chooseItem = _view.ShowAllVendingItems(items);

                int[] change = _service.CalculateReturnChange(userMoney);

                Change userChange = new Change(change[0], change[1], change[2], change[3], change[4]);

                VendingMachineItem chosenItem = new VendingMachineItem();
                
                foreach (VendingMachineItem item in items)
                {
                    if (item.Name == chooseItem)
                        chosenItem = item;
                }

                userChange = _service.BuyItem(chosenItem, userMoney);

                Console.WriteLine();

                GetResponseMessage(chosenItem);

                string changeToString = $"Dollars: {userChange.Dollar}, " +
                   $"Quarters: {userChange.Quarter}, " + $"Dimes: {userChange.Dime}, " +
                   $"Nickels: {userChange.Nickel}, " + $"Pennies: {userChange.Penny}";

                Console.WriteLine("Your change is: " + changeToString);

                Console.WriteLine();

                finished = PromptUserResponse();

                if (finished)
                    Console.WriteLine("Okie, see you next time!");
            }
        }

        public bool PromptUserResponse()
        {
            Console.Write("Buy another item? (Y/N): ");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine();
                return true;
            }
        }
    }
}
