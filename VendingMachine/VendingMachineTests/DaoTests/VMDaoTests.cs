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

        IVendingMachineDao _daoTest;

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

            Assert.AreEqual(8, toTest[1].Quantity);

            // expected 6
            _daoTest.RemoveItemQty(toTest[2]);
            _daoTest.RemoveItemQty(toTest[2]);
            _daoTest.RemoveItemQty(toTest[2]);
            _daoTest.RemoveItemQty(toTest[2]);

            Assert.AreEqual(6, toTest[2].Quantity);
        }

        [Test]
        public void ThrowItemDepletedExceptionWhenRemovingTest()
        {
            VendingMachineItem fritos = _daoTest.GetItemByName("Fritos");

            Assert.AreEqual("Fritos", fritos.Name);

            _daoTest.RemoveItemQty(fritos);

            fritos = _daoTest.GetItemByName("Fritos");

            Assert.AreEqual(0, fritos.Quantity);

            Assert.Throws<ItemDepletedException>(() => _daoTest.RemoveItemQty(fritos));
        }
    }
}