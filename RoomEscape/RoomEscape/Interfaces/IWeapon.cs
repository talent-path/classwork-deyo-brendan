using System;
namespace RoomEscape.Interfaces
{
    public interface IWeapon : INamed
    {
        public int Damage { get; set; }
        public int Durability { get; set; }

    }
}
