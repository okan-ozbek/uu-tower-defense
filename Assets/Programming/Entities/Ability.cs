using Programming.Data;
using Programming.Entities.Factories;
using Programming.Entities.Strategies;
using UnityEngine;

namespace Programming.Entities
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