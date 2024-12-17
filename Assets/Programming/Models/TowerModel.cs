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
        
        public readonly List<AttackStat> AttackStats = new();
        
        public override void Initialize()
        {
            Range = new Stat<float>(statConfig.range);
            Damage = new Stat<float>(statConfig.damage);

            foreach (TowerAttackConfig attackConfig in statConfig.attackConfigs)
            {
                AttackStat attackStat = new AttackStat(attackConfig);
                AttackStats.Add(attackStat);
            }
        }
    }
}