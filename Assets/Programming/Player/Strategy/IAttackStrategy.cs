using UnityEngine;

namespace Settings.Programming.Player.Strategy
{
    public interface IAttackStrategy
    {
        public void Use(GameObject target);
    }
}