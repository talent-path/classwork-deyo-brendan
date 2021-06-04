using System;
using RoomEscape.Abstractions;
using RoomEscape.Interfaces;

namespace RoomEscape.Concrete.Fighters
{
    public class Mercenary : Fighter
    {
        static Random _random = new Random();

        public Mercenary()
        {
        }

        public Mercenary(int health, string name, IArmor armor,
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

        public override int Health { get; set; }
        public override int Row { get; set; }
        public override int Col { get; set; }
        public override string Name { get; set; }
        public override IArmor Armor { get; set; }
        public override IWeapon Weapon { get; set; }
        public override char Symbol { get; set; }

        //20% chance to deal 10 extra damage, loses 5 durability
        public override int Attack(IFighter enemy)
        {
            int x = _random.Next(0, 6);

            int dmg = Weapon.Damage;

            if(x == 0)
            {
                dmg += 10;
                Weapon.Durability -= 5;
                return dmg;
            }

            return dmg;
        }

        public override void Defend(int incomingDamage)
        {
            int dmg = Armor.ReduceDamage(incomingDamage);
            Health -= dmg;
        }
    }
}
