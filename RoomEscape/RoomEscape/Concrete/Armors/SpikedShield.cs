using System;
using RoomEscape.Abstractions;

namespace RoomEscape.Concrete.Armors
{
    public class SpikedShield : Armor
    {
        public SpikedShield()
        {
        }

        public override string Name { get; set; } = "Spiked Shield";
        public override int Durability { get; set; }

        // 50% chance to block all damage, 50% chance to take double damage
        public override int ReduceDamage(int incomingDamage)
        {
            int toReturn = 0;

            Random random = new Random();

            int x = random.Next(0, 2);
            if (x == 0)
                toReturn = 0;
            else if (x == 1)
                toReturn = incomingDamage * 2;

            Durability -= 1;

            return toReturn;
        }
    }
}
