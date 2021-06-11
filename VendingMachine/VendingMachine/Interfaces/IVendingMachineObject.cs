using System;
using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IVendingMachineObject
    {
        public List<VendingMachineItem> Items { get; set; }
    }
}
