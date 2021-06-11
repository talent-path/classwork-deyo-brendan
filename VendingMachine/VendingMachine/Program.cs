using System;

namespace VendingMachine
{
    class Program
    {

        //        Vending Machine Requirements

        //When the application starts, the user should be presented with a list of candies and prices.
        //Users should be able to "enter money" (just type in how much they want to enter).
        //Users should be able to buy items if they've entered enough money
        //Users should not be able to buy items if they have not entered enough money
        //When a user buys an item, it should reduce the quantity stored by one and "return"
        //change(display the money to the user) showing dollars, quarters, dimes, nickles, and pennies(a Change class may help here)
        //Users should not be able to buy items that are out of stock.

        //The system should have a FileDAO for offline persistence to track candy quantities and prices from the machine.
        //The service layer should be testable using an InMemoryDao, however.
        //Unit testing the FileDAO will mean reseting the TESTING item file(this is most easily accomplished by deleting it and copying)
        //a second file such that the copy has the name items.txt)

        //Just to make official what I just said verbally: the user should also be able to get back
        //their change without vending an item(functionally as though they had vended a free item).

        static void Main(string[] args)
        {

        }

        public double GetUserMoneyFromInput()
        {
            bool finished = false;

            double toReturn = 0.0;

            while (!finished)
            {
                Console.Write("Please enter your amount of money in decimal form: ");
                string input = Console.ReadLine();
                toReturn = double.Parse(input);

                double compareType = 0.0;

                if (toReturn.GetType() == compareType.GetType())
                {
                    finished = true;
                }
                else
                {
                    Console.WriteLine("Not a valid input, please try again.");
                    Console.WriteLine();
                }
            }

            return toReturn;

        }
    }
}
