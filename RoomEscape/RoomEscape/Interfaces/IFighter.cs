using System;
namespace RoomEscape.Interfaces
{
    public interface IFighter : IHealthy, INamed
    {
        public int Attack(IFighter enemy);
        public void Defend(int incomingDamage);
        public char Symbol { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

    }
}
