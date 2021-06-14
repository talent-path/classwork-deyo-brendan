using NUnit.Framework;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.Persistence;
using VendingMachine.Services;
using System.Collections.Generic;
using System;
using VendingMachine.Exceptions;

namespace VendingMachineTests
{
    public class VMServiceTests
    {

        VendingMachineService _service;

        List<VendingMachineItem> _addItems = new List<VendingMachineItem>();

        List<VendingMachineItem> _testEmptyVM = new List<VendingMachineItem>();

        VendingMachinInMemDao _daoTest;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            VendingMachineItem item1 = new VendingMachineItem(10, 1.99m, "Babe Ruth", "Candy");
            VendingMachineItem item2 = new VendingMachineItem(10, 3.00m, "Coca Cola", "Soda");
            VendingMachineItem item3 = new VendingMachineItem(10, 1.99m, "Doritos", "Chips");
            VendingMachineItem item4 = new VendingMachineItem(10, 1.99m, "Kit Kat", "Candy");
            VendingMachineItem item5 = new VendingMachineItem(10, 2.00m, "Sprite", "Soda");
            VendingMachineItem item6 = new VendingMachineItem(0, 1.99m, "Lays", "Chips");
            VendingMachineItem item7 = new VendingMachineItem(0, 3.00m, "Barq's Root Beer", "Soda");
            VendingMachineItem item8 = new VendingMachineItem(0, 1.99m, "Fritos", "Chips");
            _addItems.Add(item1);
            _addItems.Add(item2);
            _addItems.Add(item3);
            _addItems.Add(item4);
            _addItems.Add(item5);
            _addItems.Add(item6);
            _addItems.Add(item7);
            _addItems.Add(item8);
        }

        [SetUp]
        public void Setup()
        {
            _daoTest = new VendingMachinInMemDao();
            _service = new VendingMachineService(_daoTest);
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

        [TestCase("Kool-Aid","Chips",10, 1.99)]
        [TestCase("Pizza Chips", "Chips", 10, 1.99)]
        [TestCase("Everything Bagel", "Chips", 10, 1.99)]
        public void ThrowItemDoesNotExistExceptionTest(string name, string category, int qty, decimal price)
        {
            VendingMachineItem toTest = new VendingMachineItem
            {
                Category = category,
                Name = name,
                Quantity = qty,
                Price = price
            };

            Assert.Throws<ItemDoesNotExistException>(() => _daoTest.GetItemByName(toTest.Name));
        }

        [Test]
        public void ShouldNotBeAbleToBuyExpensiveItem()
        {
            decimal userMoney = .50m;

            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[0], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[1], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[2], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[3], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[4], userMoney));

        }

        [Test]
        public void ShouldNotBeAbleToBuyDepletedItem()
        {
            decimal userMoney = .50m;

            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[0], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[1], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[2], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[3], userMoney));
            Assert.Throws<NotEnoughMoneyException>(() => _service.BuyItem(_addItems[4], userMoney));
        }

        [TestCase(-9.99)]
        [TestCase(-.01)]
        [TestCase(-10)]
        public void NegativeUserMoneyExceptionThrownTest(decimal userMoney)
        {
            Assert.Throws<InvalidUserMoneyException>(() => _service.BuyItem(_addItems[0], userMoney));
        }

        [Test]
        public void AssertCorrectChangeAfterPurchaseTest()
        {
            decimal userMoney = 5.00m;

            Change toTest = _service.BuyItem(_addItems[0], userMoney);

            //VendingMachineItem item1 = new VendingMachineItem(10, 1.99m, "Babe Ruth", "Candy");

            // Item 1
            // Test 1, 3 dollars, 1 penny

            Assert.AreEqual(3, toTest.Dollar);
            Assert.AreEqual(1, toTest.Penny);

            userMoney = 8.59m;

            toTest = _service.BuyItem(_addItems[1], userMoney);

            //VendingMachineItem item2 = new VendingMachineItem(10, 3.00m, "Coca Cola", "Soda");

            // Item 2
            // Test 2, 5 dollars, 2 quarters, 1 nickel, 4 pennies

            Assert.AreEqual(5, toTest.Dollar);
            Assert.AreEqual(2, toTest.Quarter);
            Assert.AreEqual(1, toTest.Nickel);
            Assert.AreEqual(4, toTest.Penny);


            userMoney = 3.12m;

            toTest = _service.BuyItem(_addItems[3], userMoney);

            //VendingMachineItem item4 = new VendingMachineItem(10, 1.99m, "Kit Kat", "Candy");

            // Item 3
            // Test 2, 1 dollar, 1 dime, 3 pennies

            Assert.AreEqual(1, toTest.Dollar);
            Assert.AreEqual(1, toTest.Dime);
            Assert.AreEqual(3, toTest.Penny);
        }

        [TestCase(-1.00)]
        [TestCase(-10.00)]
        [TestCase(-.01)]
        public void ThrowTransactionFailedExceptionTest(decimal userMoney)
        {
            Assert.Throws<TransactionFailedException>(() => _service.CalculateReturnChange(userMoney));
        }

    }


}