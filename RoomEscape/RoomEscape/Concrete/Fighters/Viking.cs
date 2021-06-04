using System;
using RoomEscape.Abstractions;
using RoomEscape.Interfaces;

namespace RoomEscape.Concrete.Fighters
{
    public class Viking : Fighter
    {
        static Random _random = new Random();

        public Viking()
        {
        }

        public Viking(int health, string name, IArmor armor, IWeapon weapon, char symbol, int row, int col)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
            Symbol = symbol;
            Row = row;
            Col = col;
        }

        public override int Health { get; set; }
        public override int Row { get; set; }
        public override int Col { get; set; }
        public override string Name { get; set; }
        public override IArmor Armor { get; set; }
        public override IWeapon Weapon { get; set; }
        public override char Symbol { get; set; }

        public override int Attack(IFighter enemy)
        {
            int dmg = Weapon.Damage;
            return dmg;
        }

        //50% chance to block 50% damage and increase Weapon dmg by 1
        public override void Defend(int incomingDamage)
        {
            int x = _random.Next(0, 2);

            int dmg = Armor.ReduceDamage(incomingDamage);

            if (x == 1)
            {
                dmg /= 2;
                Health -= dmg;
                Weapon.Damage += 1;
            }

            else
                Health -= dmg;
        }
    }
}
