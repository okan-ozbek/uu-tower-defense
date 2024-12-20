using UnityEngine;

namespace Programming.Abilities.Strategies
{
    public interface IAbilityStrategy
    {
        public void Use(GameObject self);
    }
}