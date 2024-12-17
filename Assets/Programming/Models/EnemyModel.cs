using System;
using Programming.Configs;
using Programming.Stats;
using UnityEngine;

namespace Programming.Models
{
    public class EnemyModel : Model
    {
        [SerializeField] private EnemyStatConfig statConfig;
        
        public Stat<float> Health;
        public Stat<float> Damage;
        public Stat<float> Speed;
        public Stat<float> Money;
        
        public override void Initialize()
        {
            Health = new Stat<float>(statConfig.health);
            Damage = new Stat<float>(statConfig.damage);
            Speed = new Stat<float>(statConfig.speed);
            Money = new Stat<float>(statConfig.money);
        }

        public Stat<float> GetStat(StatType statType) => statType switch
        {
            StatType.Health => Health,
            StatType.Damage => Damage,
            StatType.Speed => Speed,
            _ => throw new ArgumentException($"Invalid stat type: {statType}", nameof(statType))
        };
    }
}