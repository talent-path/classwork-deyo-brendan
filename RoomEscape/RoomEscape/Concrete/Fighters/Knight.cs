using System;
using RoomEscape.Abstractions;
using RoomEscape.Interfaces;

namespace RoomEscape.Concrete.Fighters
{
    public class Knight : Fighter
    {

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
