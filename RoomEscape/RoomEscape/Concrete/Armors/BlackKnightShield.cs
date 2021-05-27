using System;
using RoomEscape.Abstractions;

namespace RoomEscape.Concrete.Armors
{
    public class BlackKnightShield : Armor
    {
        public BlackKnightShield()
        {
        }

        public override string Name { get; set; }
        public override int Durability { get; set; }

        // 33% chance to block 50% of incoming damage
        public override int ReduceDamage(int incomingDamage)
        {
            int toReturn = 0;

            Random random = new Random();
            int x = random.Next(0, 3);
            if (x == 2)
                toReturn = incomingDamage / 2;
            else
                toReturn = incomingDamage;

            Durability -= 1;

            return toReturn;
        }
    }
}
