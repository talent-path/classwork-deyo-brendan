using System;
using RoomEscape.Abstractions;

namespace RoomEscape.Concrete.Armors
{
    public class PurpleFlameShield : Armor
    {
        public PurpleFlameShield()
        {
        }

        public override string Name { get; set; }
        public override int Durability { get; set; }

        // 10% chance to block all incoming damage, 50% chance to retain durability
        public override int ReduceDamage(int incomingDamage)
        {
            int toReturn = 0;

            Random random = new Random();

            int x = random.Next(0, 10);

            if (x == 2)
                toReturn = incomingDamage / 10;
            else
                toReturn = incomingDamage;

            int y = random.Next(0, 2);

            if (y == 1)
                Durability -= 0;
            else
                Durability -= 1;

            return toReturn;

        }
    }
}
