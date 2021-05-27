using System;
using RoomEscape.Interfaces;

namespace RoomEscape.Abstractions
{
    public abstract class Fighter : IFighter
    {
        public Fighter()
        {
        }

        public abstract int Health { get; set; }
        public abstract string Name { get; set; }
        public abstract IArmor Armor { get; set; }
        public abstract IWeapon Weapon { get; set; }
        public abstract int Attack(IFighter enemy);
        public abstract void Defend(int incomingDamage);
    }
}
