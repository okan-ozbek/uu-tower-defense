using System.Collections.Generic;
using Programming.Configs;
using Programming.Stats;
using UnityEngine;

namespace Programming.Models
{
    public class TowerModel : Model
    {
        [SerializeField] private TowerStatConfig statConfig;
        
        public Stat<float> Range;
        public Stat<float> Damage;

        public float Cost => statConfig.cost;
        
        public readonly List<AbilityStat> AbilityStats = new();
        
        public override void Initialize()
        {
            Range = new Stat<float>(statConfig.range);
            Damage = new Stat<float>(statConfig.damage);

            foreach (TowerAbilityConfig attackConfig in statConfig.abilityConfigs)
            {
                AbilityStat abilityStat = new AbilityStat(attackConfig);
                AbilityStats.Add(abilityStat);
            }
        }
    }
}