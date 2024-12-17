using Programming.Stats;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public interface IAbilityStrategy
    {
        public void Use(GameObject target, AbilityStat abilityStat);
        public bool Validated(GameObject target, AbilityStat abilityStat);
    }
}