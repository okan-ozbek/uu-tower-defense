using System.Collections.Generic;
using Programming.Configs;
using Programming.Entities.Stats;
using UnityEngine;

namespace Programming.Models
{
    public class TowerModel : Model
    {
        [SerializeField] private TowerStatConfig statConfig;
        
        public GenericStat<float> Damage;

        public float Cost => statConfig.cost;
        public float Range => statConfig.range;
        
        public readonly List<AbilityStat> AbilityStats = new();
        
        public override void Initialize()
        {
            Damage = new GenericStat<float>(statConfig.damage);

            foreach (TowerAbilityConfig attackConfig in statConfig.abilityConfigs)
            {
                AbilityStat abilityStat = new AbilityStat(attackConfig);
                AbilityStats.Add(abilityStat);
            }
        }
    }
}