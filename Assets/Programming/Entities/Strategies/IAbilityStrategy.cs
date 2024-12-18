using Programming.Entities.Stats;
using UnityEngine;

namespace Programming.Entities.Strategies
{
    public interface IAbilityStrategy
    {
        public void Use(GameObject target, AbilityStat abilityStat);
        public bool Validated(GameObject target, AbilityStat abilityStat);
    }
}