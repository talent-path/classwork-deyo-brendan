using System;
using RoomEscape.Abstractions;
using RoomEscape.Interfaces;

namespace RoomEscape.Concrete.Fighters
{
    public class Viking : Fighter
    {
        public Viking()
        {
        }

        public Viking(int health, string name, IArmor armor, IWeapon weapon)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
        }

        public override int Health { get; set; }
        public override string Name { get; set; }
        public override IArmor Armor { get; set; }
        public override IWeapon Weapon { get; set; }

        public override int Attack(IFighter enemy)
        {
            throw new NotImplementedException();
        }

        public override void Defend(int incomingDamage)
        {
            throw new NotImplementedException();
        }
    }
}
