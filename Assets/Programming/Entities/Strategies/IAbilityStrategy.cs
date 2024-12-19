using UnityEngine;

namespace Programming.Entities.Strategies
{
    public interface IAbilityStrategy
    {
        public void Use(GameObject self);
    }
}