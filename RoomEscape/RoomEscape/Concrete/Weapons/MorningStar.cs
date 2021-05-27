using System;
using RoomEscape.Abstractions;

namespace RoomEscape.Concrete.Weapons
{
    public class MorningStar : Weapon
    {
        public MorningStar()
        {
            Random random = new Random();
            Damage = random.Next(5, 21);

        }

        public override int Damage { get; set; }
        public override int Durability { get; set; } = 50;
        public override string Name { get; set; } = "Morning Star";
    }
}
