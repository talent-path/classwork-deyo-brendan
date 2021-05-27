using System;
using RoomEscape.Abstractions;

namespace RoomEscape.Concrete.Weapons
{
    public class GreatScythe : Weapon
    {
        public GreatScythe()
        {
            Random random = new Random();
            int x = random.Next(0, 2);
            if (x == 1)
                Damage = 35;
            if (x == 0)
                Damage = 10;

        }

        public override int Damage { get; set; }
        public override int Durability { get; set; } = 50;
        public override string Name { get; set; } = "Great Scythe";
    }
}
