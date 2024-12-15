using UnityEngine;

namespace Settings.Programming.Player.Strategy
{
    public interface IAttackStrategy
    {
        public void Shoot(GameObject target);
    }
}