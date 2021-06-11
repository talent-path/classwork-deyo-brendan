using System;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace VendingMachine.Persistence
{
    public class VendingMachinInMemDao : IVendingMachineDao
    {
        List<VendingMachineItem> _addItems = new List<VendingMachineItem>();

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

        public VendingMachinInMemDao()
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

        public List<VendingMachineItem> GetAllVMItems()
        {
            List<VendingMachineItem> toReturn = _addItems.Where(i => i != null).ToList();
            return toReturn;
        }

        public void RemoveItemQty(VendingMachineItem item)
        {
            _addItems = _addItems.Select(i => i.Name ==
                item.Name ? new VendingMachineItem(i.Quantity, i.Price, i.Name, i.Category) : i).ToList();
        }

    }
}
