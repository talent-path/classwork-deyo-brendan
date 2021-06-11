using System;
using System.Collections.Generic;
using System.IO;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Persistence
{
    public class ItemFileDao : IVendingMachineDao
    {
        public ItemFileDao()
        {

        }

        public List<VendingMachineItem> GetAllVMItems()
        { 
            List<VendingMachineItem> items = new List<VendingMachineItem>();

            string line = "";

            using (StreamReader reader = new StreamReader("../../../items.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] toAdd = line.Split(",");
                    string itemName = toAdd[0];
                    double itemPrice = double.Parse(toAdd[1]);
                    int itemQty = int.Parse(toAdd[2]);
                    string itemCategory = toAdd[3];

                    VendingMachineItem itemToAdd = new VendingMachineItem(itemQty, itemPrice, itemName, itemCategory);
                    items.Add(itemToAdd);
                }
            }

            return items;
        }

        public void RemoveItemQty(VendingMachineItem item)
        {
            throw new NotImplementedException();
        }
    }
}
