using System;
using System.Collections.Generic;
using System.IO;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.Exceptions;
using System.Linq;

namespace VendingMachine.Persistence
{
    public class ItemFileDao : IVendingMachineDao
    {
        public string Filepath { get; set; }  

        public ItemFileDao(string file) 
        {
            Filepath = file;
        }

        private void OverrideItemFile(List<VendingMachineItem> items)
        {
            string writeLine = "";

            foreach(VendingMachineItem item in items)
            {
                writeLine += $"{item.Name},{item.Price}," +
                    $"{item.Quantity},{item.Category}" + Environment.NewLine;
            }

            File.WriteAllText(Filepath, writeLine);
        }

        public void ResetItemFile(List<VendingMachineItem> items)
        {
            string writeLine = "";

            foreach(VendingMachineItem item in items)
            {
                if (item.Name == "Doritos" || item.Name == "Sprite")
                    item.Quantity = 2;
                else
                    item.Quantity = 10;

                writeLine += $"{item.Name},{item.Price}," +
                    $"{item.Quantity},{item.Category}" + Environment.NewLine;
            }

            File.WriteAllText(Filepath, writeLine);
        }

        public VendingMachineItem GetItemByName(string name)
        {
            List<VendingMachineItem> items = GetAllVMItems();

            VendingMachineItem toReturn = new VendingMachineItem();

            toReturn = items.SingleOrDefault(i => i.Name == name);

            if (toReturn == null)
                throw new ItemDoesNotExistException("No item was found with that given name");

            return toReturn;
        }

        public List<VendingMachineItem> GetAllVMItems()
        { 
            List<VendingMachineItem> items = new List<VendingMachineItem>();

            string line = "";

            using (StreamReader reader = new StreamReader(Filepath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] toAdd = line.Split(",");
                    string itemName = toAdd[0];
                    decimal itemPrice = decimal.Parse(toAdd[1]);
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
            List<VendingMachineItem> items = GetAllVMItems();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item.Name)
                {
                    if (item.Quantity <= 0)
                        throw new ItemDepletedException("There are no more items of this name left");
                    else
                    {
                        items = items.Select(i => i.Name == item.Name ?
                        new VendingMachineItem(i.Quantity - 1, i.Price, i.Name, i.Category) : i).ToList();

                        OverrideItemFile(items);
                    }
                }
            }
        }
    }
}
