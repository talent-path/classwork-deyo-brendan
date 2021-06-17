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

        public void StartVendingMachineApp(decimal userMoney)
        {
            _fileDao.ResetItemFile(_fileDao.GetAllVMItems());

            while (userMoney > 0)
            {
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

                if (chosenItem.Category == "Candy")
                {
                    Console.WriteLine("You have purchased a: " + chosenItem.Name + "..... MMMMMMM, YUMMY");
                    Console.WriteLine();
                }
                else if (chosenItem.Category == "Chips")
                {
                    Console.WriteLine("You have purchased a bag of: " + chosenItem.Name + "..... MMMMMMM, CRUNCHY");
                    Console.WriteLine();
                }
                else if (chosenItem.Category == "Soda")
                {
                    Console.WriteLine("You have purchased a bottle of: " + chosenItem.Name + "..... OOOOO, REFRESHING");
                    Console.WriteLine();
                }
                else
                    throw new ItemDoesNotExistException("I'm confused, this should not be possible");

                string changeToString = $"Dollars: {userChange.Dollar}, " +
                   $"Quarters: {userChange.Quarter}, " + $"Dimes: {userChange.Dime}, " +
                   $"Nickels: {userChange.Nickel}, " + $"Pennies: {userChange.Penny}";

                Console.WriteLine("Current money for user: " + changeToString);

                Console.WriteLine();
            }
        }
    }
}
