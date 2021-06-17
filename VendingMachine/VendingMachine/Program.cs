using System;
using System.Collections.Generic;
using VendingMachine.Controllers;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.Persistence;
using VendingMachine.Services;
using VendingMachine.View;

namespace VendingMachine
{
    class Program
    {

        //        Vending Machine Requirements

        //When the application starts, the user should be presented with a list of candies and prices.
        //Users should be able to "enter money" (just type in how much they want to enter).
        //Users should be able to buy items if they've entered enough money
        //Users should not be able to buy items if they have not entered enough money
        //When a user buys an item, it should reduce the quantity stored by one and "return"
        //change(display the money to the user) showing dollars, quarters, dimes, nickles, and pennies(a Change class may help here)
        //Users should not be able to buy items that are out of stock.

        //The system should have a FileDAO for offline persistence to track candy quantities and prices from the machine.
        //The service layer should be testable using an InMemoryDao, however.
        //Unit testing the FileDAO will mean reseting the TESTING item file(this is most easily accomplished by deleting it and copying)
        //a second file such that the copy has the name items.txt)

        //Just to make official what I just said verbally: the user should also be able to get back
        //their change without vending an item(functionally as though they had vended a free item).

        private static VendingMachineController _controller;

        private static VendingMachineService _service;

        private static ItemFileDao _fileDao;

        private static VendingMachineView _view = new VendingMachineView();

        static void Main(string[] args)
        {
            _fileDao =
                new ItemFileDao(@"/Users/brendandeyo/Desktop/classwork-deyo-brendan/VendingMachine/VendingMachine/ItemList.txt");

            _service = new VendingMachineService(_fileDao);

            _controller = new VendingMachineController(_service, _view);

            decimal userMoney = GetUserMoney();

            _controller.StartVendingMachineApp(userMoney);
            
        }

        public static decimal GetUserMoney()
        {
            decimal toReturn = 0;

            bool canParse = false;

            while (!canParse)
            {
                Console.Write("Please enter a money amount for user: ");
                string toParse = Console.ReadLine();

                canParse = decimal.TryParse(toParse, out toReturn);
            }

            Console.WriteLine();

            return toReturn;
        }

        //public decimal GetUserMoneyFromInput()
        //{
        //    bool finished = false;

        //    decimal toReturn = 0;

        //    while (!finished)
        //    {
        //        Console.Write("Please enter your amount of money in decimal form: ");
        //        string input = Console.ReadLine();
        //        toReturn = decimal.Parse(input);

        //        decimal compareType = 0;

        //        if (toReturn.GetType() == compareType.GetType())
        //        {
        //            finished = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Not a valid input, please try again.");
        //            Console.WriteLine();
        //        }
        //    }

        //    return toReturn;
        //}

    }
}
