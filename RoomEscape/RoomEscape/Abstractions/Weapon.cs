using System;
using RoomEscape.Interfaces;

namespace RoomEscape.Abstractions
{
    public abstract class Weapon : IWeapon
    {
        public Weapon()
        {
        }

        public abstract int Damage { get; set; }
        public abstract int Durability { get; set; }
        public abstract string Name { get; set; }
    }
}
