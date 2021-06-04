using System;
using RoomEscape.Abstractions;
using RoomEscape.Interfaces;

namespace RoomEscape.Concrete.Fighters
{
    public class Knight : Fighter
    {
        static Random _random = new Random();

        public Knight(int health, string name, IArmor armor,
            IWeapon weapon, char symbol, int row, int col)
        {
            Health = health;
            Name = name;
            Armor = armor;
            Weapon = weapon;
            Symbol = symbol;
            Row = row;
            Col = col;
        }

        public Knight()
        {
        }

        public override int Health { get; set; }
        public override int Row { get; set; }
        public override int Col { get; set; }
        public override string Name { get; set; }
        public override IArmor Armor { get; set; }
        public override IWeapon Weapon { get; set; }
        public override char Symbol { get; set; }

        //50% to do 2 points of additional damage
        public override int Attack(IFighter enemy)
        {
            int x = _random.Next(0, 2);

            int dmg = Weapon.Damage;

            if (x == 0)
            {
                dmg += 2;
                return dmg;
            }
            else
                return dmg;

        }

        //33% chance to block all damage because Knights are OD.
        public override void Defend(int incomingDamage)
        {
            int x = _random.Next(3);

            if (x == 2)
            {
                incomingDamage = 0;
            }
            else
            {
                int dmg = Armor.ReduceDamage(incomingDamage);
                Health -= dmg;
            }
        }
    }
}
