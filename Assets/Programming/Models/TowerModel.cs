using System.Collections.Generic;
using Programming.Configs;
using Programming.Stats;
using UnityEngine;

namespace Programming.Models
{
    public class TowerModel : Model
    {
        [SerializeField] private TowerStatConfig statConfig;
        
        public GenericStat<float> Range;
        public GenericStat<float> Damage;

        public float Cost => statConfig.cost;
        
        public readonly List<AbilityStat> AbilityStats = new();
        
        public override void Initialize()
        {
            Range = new GenericStat<float>(statConfig.range);
            Damage = new GenericStat<float>(statConfig.damage);

            foreach (TowerAbilityConfig attackConfig in statConfig.abilityConfigs)
            {
                AbilityStat abilityStat = new AbilityStat(attackConfig);
                AbilityStats.Add(abilityStat);
            }
        }
    }
}