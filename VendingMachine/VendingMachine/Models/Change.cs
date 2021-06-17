using System;
namespace VendingMachine.Models
{
    public class Change
    {
        public Change()
        {

        }

        public Change(int dollar, int quarter,
            int dime, int nickel, int penny)
        {
            Dollar = dollar;
            Quarter = quarter;
            Dime = dime;
            Nickel = nickel;
            Penny = penny;
        }

        public int Dollar { get; set; }
        public int Quarter { get; set; }
        public int Dime { get; set; }
        public int Nickel { get; set; }
        public int Penny { get; set; }


    }
}
