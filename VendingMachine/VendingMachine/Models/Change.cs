using System;
namespace VendingMachine.Models
{
    public class Change
    {
        public Change()
        {

        }

        public Change(decimal dollar, decimal quarter,
            decimal dime, decimal nickel, decimal penny)
        {
            Dollar = dollar;
            Quarter = quarter;
            Dime = dime;
            Nickel = nickel;
            Penny = penny;
        }

        public decimal Dollar { get; set; }
        public decimal Quarter { get; set; }
        public decimal Dime { get; set; }
        public decimal Nickel { get; set; }
        public decimal Penny { get; set; }

    }
}
