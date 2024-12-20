using Programming.Abilities.Factories;
using Programming.Abilities.Strategies;
using Programming.Data;
using UnityEngine;

namespace Programming.Abilities
{
    public class Ability
    {
        private AbstractAbilityData _data;
        private IAbilityStrategy _strategy;

        public Ability(AbstractAbilityData data)
        {
            _data = data;
            _strategy = AbilityStrategyFactory.Create(_data);
        }

        public void Use(GameObject self)
        {
            _strategy.Use(self);
        }

        public void Upgrade(AbstractAbilityData data)
        {
            _data = data;
            _strategy = AbilityStrategyFactory.Create(data);
        }
    }
}