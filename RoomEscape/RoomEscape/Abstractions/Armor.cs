using System;
using RoomEscape.Interfaces;

namespace RoomEscape.Abstractions
{
    public abstract class Armor : IArmor
    {
        public Armor()
        {
        }

        public abstract int ReduceDamage(int incomingDamage);
        public abstract string Name { get; set; }
        public abstract int Durability { get; set; }

    }
}
