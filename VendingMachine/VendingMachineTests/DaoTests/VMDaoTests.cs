using NUnit.Framework;
using VendingMachine.Exceptions;
using VendingMachine.Models;
using VendingMachine.Services;
using VendingMachine.Interfaces;
using VendingMachine.Persistence;
using System.Collections.Generic;

namespace VendingMachineTests
{
    public class VMDaoTests
    {
        ItemFileDao _daoTest;

        private string _testFile = @"/Users/brendandeyo/Desktop/classwork-deyo-brendan/VendingMachine/VendingMachine/TestFile.txt";

        //Babe Ruth,1.99,10, Candy
        //Coca Cola,3.00,10, Soda
        //Doritos,1.99,10,Chips
        //Kit Kat,1.99,10,Candy
        //Sprite,2.00,10, Soda
        //Lays,1.99,10,Chips
        //Reese's Peanut Butter Cup,1.99,10,Candy
        //Barq's Root Beer,3.00,10,Soda
        //Flamin' Hot Cheetos,1.99,10,Chips
        //Milky Way,1.99,10, Candy
        //Dr.Pepper,3.00,10,Soda
        //Fritos,1.99,10, Chips

        [SetUp]
        public void Setup()
        {
            _daoTest = new ItemFileDao(_testFile);
            _daoTest.ResetItemFile(_daoTest.GetAllVMItems());
        }

        [Test]
        public void TestGetAllVendingMachineItemsGoldenPath()
        {
            List<VendingMachineItem> toTest = _daoTest.GetAllVMItems();
            VendingMachineItem item1 = toTest[0];
            VendingMachineItem item2 = toTest[1];
            VendingMachineItem item3 = toTest[2];
            VendingMachineItem item4 = toTest[3];
            VendingMachineItem item5 = toTest[4];

            //Testing Item 1 Comparison
            Assert.AreEqual("Babe Ruth", item1.Name);
            Assert.AreEqual(1.99, item1.Price);
            Assert.AreEqual(10, item1.Quantity);
            Assert.AreEqual("Candy", item1.Category);

            //Testing Item 2 Comparison
            Assert.AreEqual("Coca Cola", item2.Name);
            Assert.AreEqual(3.00, item2.Price);
            Assert.AreEqual(10, item2.Quantity);
            Assert.AreEqual("Soda", item2.Category);

            //Testing Item 3 Comparison
            Assert.AreEqual("Doritos", item3.Name);
            Assert.AreEqual(1.99, item3.Price);
            Assert.AreEqual(10, item3.Quantity);
            Assert.AreEqual("Chips", item3.Category);

            //Testing Item 4 Comparison
            Assert.AreEqual("Kit Kat", item4.Name);
            Assert.AreEqual(1.99, item4.Price);
            Assert.AreEqual(10, item4.Quantity);
            Assert.AreEqual("Candy", item4.Category);

            //Testing Item 5 Comparison
            Assert.AreEqual("Sprite", item5.Name);
            Assert.AreEqual(2.00, item5.Price);
            Assert.AreEqual(10, item5.Quantity);
            Assert.AreEqual("Soda", item5.Category);
        }

        [Test]
        public void TestRemoveItemFromVendingMachineGoldenPath()
        {
            List<VendingMachineItem> toTest = _daoTest.GetAllVMItems();

            // expected 8
            _daoTest.RemoveItemQty(toTest[1]);
            _daoTest.RemoveItemQty(toTest[1]);

            toTest = _daoTest.GetAllVMItems();

            Assert.AreEqual(8, toTest[1].Quantity);

            // expected 6
            _daoTest.RemoveItemQty(toTest[2]);
            _daoTest.RemoveItemQty(toTest[2]);
            _daoTest.RemoveItemQty(toTest[2]);
            _daoTest.RemoveItemQty(toTest[2]);

            toTest = _daoTest.GetAllVMItems();

            Assert.AreEqual(6, toTest[2].Quantity);

            
        }

        [Test]
        public void ThrowItemDepletedExceptionWhenRemovingTest()
        {
            VendingMachineItem fritos = _daoTest.GetItemByName("Fritos");

            Assert.AreEqual("Fritos", fritos.Name);

            for(int i = 1; i <= 10; i++)
                _daoTest.RemoveItemQty(fritos);

            fritos = _daoTest.GetItemByName("Fritos");

            Assert.AreEqual(0, fritos.Quantity);

            Assert.Throws<ItemDepletedException>(() => _daoTest.RemoveItemQty(fritos));
        }

        [TestCase("Moonshine")]
        [TestCase("Soda Pop")]
        [TestCase("Gooberberry Ice Cream")]
        public void ThrowItemDoesNotExistException(string name)
        {
            Assert.Throws<ItemDoesNotExistException>(() => _daoTest.GetItemByName(name));
        }

        [TestCase("Fritos")]
        [TestCase("Coca Cola")]
        [TestCase("Kit Kat")]
        [TestCase("Doritos")]
        public void TestGetVendingItemByNameGoldenPath(string name)
        {
            VendingMachineItem getItem = _daoTest.GetItemByName(name);

            Assert.AreEqual(name, getItem.Name);
        }

        [Test]
        public void TestResetItemFileGoldenPath()
        {
            List<VendingMachineItem> items = _daoTest.GetAllVMItems();

            _daoTest.ResetItemFile(items);

            VendingMachineItem item1 = items[0];
            VendingMachineItem item2 = items[1];
            VendingMachineItem item3 = items[2];
            VendingMachineItem item4 = items[3];
            VendingMachineItem item5 = items[4];
            VendingMachineItem item6 = items[5];
            VendingMachineItem item7 = items[6];
            VendingMachineItem item8 = items[7];
            VendingMachineItem item9 = items[8];
            VendingMachineItem item10 = items[9];
            VendingMachineItem item11 = items[10];

            Assert.AreEqual(10, item1.Quantity);
            Assert.AreEqual(10, item2.Quantity);
            Assert.AreEqual(10, item3.Quantity);
            Assert.AreEqual(10, item4.Quantity);
            Assert.AreEqual(10, item5.Quantity);
            Assert.AreEqual(10, item6.Quantity);
            Assert.AreEqual(10, item7.Quantity);
            Assert.AreEqual(10, item8.Quantity);
            Assert.AreEqual(10, item9.Quantity);
            Assert.AreEqual(10, item10.Quantity);
            Assert.AreEqual(10, item11.Quantity);
        }
    }
}