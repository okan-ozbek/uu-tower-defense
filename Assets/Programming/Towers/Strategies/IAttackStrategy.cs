using UnityEngine;

namespace Programming.Towers.Strategies
{
    public interface IAttackStrategy
    {
        public void Use(GameObject target);
    }
}