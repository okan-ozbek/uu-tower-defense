using System;
using Configs;
using Enums;
using UnityEngine;
using Utility;

namespace Models
{
    public class Tower : Model
    {
        [SerializeField] private TowerConfig config;
        
        public Sprite Icon => config.icon;
        public Guid Guid { get; private set; }
        public AttackPatternType AttackPatternType => config.attackPatternType;
        public int Count => config.count;
        public float BurstCooldown => config.burstCooldown;
        public float Cost => config.cost;
        public float Sell => config.cost * 0.7f;
        public float BaseRange => config.range;
        public float BaseCooldown => config.cooldown;
        public bool IsStationary => config.isStationary;
        
        public Stat<float> Range;
        public Stat<float> Cooldown;
        
        protected override void Start()
        {
            Guid = Guid.NewGuid();
            
            Range.Value = config.range;
            Cooldown.Value = config.cooldown;
        }
    }
}