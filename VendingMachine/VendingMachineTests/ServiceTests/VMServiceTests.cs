using NUnit.Framework;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.Persistence;
using VendingMachine.Services;
using System.Collections.Generic;

namespace VendingMachineTests
{
    public class VMServiceTests
    {

        IVendingMachineService _service;

        List<VendingMachineItem> _addItems = new List<VendingMachineItem>();


        [OneTimeSetUp]
        public void Setup()
        {
            VendingMachineItem item1 = new VendingMachineItem(10, 1.99, "Babe Ruth", "Candy");
            VendingMachineItem item2 = new VendingMachineItem(10, 3.00, "Coca Cola", "Soda");
            VendingMachineItem item3 = new VendingMachineItem(10, 1.99, "Doritos", "Chips");
            VendingMachineItem item4 = new VendingMachineItem(10, 1.99, "Kit Kat", "Candy");
            VendingMachineItem item5 = new VendingMachineItem(10, 2.00, "Sprite", "Soda");
            VendingMachineItem item6 = new VendingMachineItem(10, 1.99, "Lays", "Chips");
            VendingMachineItem item7 = new VendingMachineItem(10, 3.00, "Barq's Root Beer", "Soda");
            VendingMachineItem item8 = new VendingMachineItem(10, 1.99, "Fritos", "Chips");
            _addItems.Add(item1);
            _addItems.Add(item2);
            _addItems.Add(item3);
            _addItems.Add(item4);
            _addItems.Add(item5);
            _addItems.Add(item6);
            _addItems.Add(item7);
            _addItems.Add(item8);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //[TestCase]
        //public void UserNotAbleToPurchaseItemWithLessMoney(VendingMachineItem item, double userMoney)
        //{

        //}

        //[TestCase("Funnyins", 10, 99.99, "Chips")]
        //[TestCase("Apple Cider", 10, 1.99, "Soda")]
        //[TestCase("Mike & Ike's", 10, 9.99, "Candy")]
        //[TestCase("Mountain Dew", 10, 0.99, "Soda")]
        //public void ShouldNotBeAbleToRemoveItemThatDoesNotExist(string name, int quantity, double price, string category)
        //{
        //    VendingMachineItem toTest = new VendingMachineItem()
        //    {
        //        Name = name,
        //        Quantity = quantity,
        //        Price = price,
        //        Category = category
        //    };
        //}

        [Test]
        public void GetAllVendingMachineItemsGoldenPath()
        {
            List<VendingMachineItem> toTest = _service.GetAllVendingMachineItems();

            Assert.AreEqual(8, toTest.Count);

        }

    }


}