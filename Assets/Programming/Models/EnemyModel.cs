using System;
using Programming.Configs;
using Programming.Entities.Enums;
using Programming.Entities.Stats;
using UnityEngine;

namespace Programming.Models
{
    public class EnemyModel : Model
    {
        [SerializeField] private EnemyStatConfig statConfig;
        
        public GenericStat<float> Health;
        public GenericStat<float> Damage;
        public GenericStat<float> Speed;
        public GenericStat<float> Money;
        
        public override void Initialize()
        {
            Health = new GenericStat<float>(statConfig.health);
            Damage = new GenericStat<float>(statConfig.damage);
            Speed = new GenericStat<float>(statConfig.speed);
            Money = new GenericStat<float>(statConfig.money);
        }

        public GenericStat<float> GetStat(StatType statType) => statType switch
        {
            StatType.Health => Health,
            StatType.Damage => Damage,
            StatType.Speed => Speed,
            _ => throw new ArgumentException($"Invalid stat type: {statType}", nameof(statType))
        };
    }
}