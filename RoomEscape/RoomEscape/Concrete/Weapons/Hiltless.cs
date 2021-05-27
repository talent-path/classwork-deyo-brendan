using System;
using RoomEscape.Abstractions;

namespace RoomEscape.Concrete.Weapons
{
    public class Hiltless : Weapon
    {
        public Hiltless()
        {
            Random random = new Random();
            Damage = random.Next(1, 31);

        }

        public override int Damage { get; set; }
        public override int Durability { get; set; } = 50;
        public override string Name { get; set; } = "Hiltless";
    }
}
