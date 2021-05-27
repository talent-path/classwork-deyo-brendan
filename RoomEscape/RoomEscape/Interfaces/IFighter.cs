using System;
namespace RoomEscape.Interfaces
{
    public interface IFighter : IHealthy, INamed
    {
        public int Attack(IFighter enemy);
        public void Defend(int incomingDamage);
        public bool IsBleeding();

    }
}
