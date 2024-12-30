using System;
using Configs;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

namespace Models
{
    public class Tower : Model
    {
        [SerializeField] private TowerConfig config;
        
        public Stat<float> Range;
        public Stat<float> Cooldown;
        public Stat<float> Spent;

        public bool isRangeMaxed;
        public bool isSpeedMaxed;
        public bool isUpgradeMaxed;
        
        protected override void Start()
        {
            Guid = Guid.NewGuid();
            
            Range.Value = config.range;
            Cooldown.Value = config.cooldown;
            Spent.Value = config.cost;

            isRangeMaxed = false;
            isSpeedMaxed = false;
            isUpgradeMaxed = false;
        }
        
        public Sprite Icon => config.icon;
        public Guid Guid { get; private set; }
        
        public float Cost => config.cost;
        public float Sell => Spent.Value * 0.7f;
        public float BaseRange => config.range;
        public float BaseCooldown => config.cooldown;
        
        public int MaxRangeUpgrades => config.maxRangeUpgrades;
        public int MaxSpeedUpgrades => config.maxSpeedUpgrades;
        public int MaxUpgradeUpgrades => config.maxUpgradeUpgrades;
        
        public bool IsStationary => config.isStationary;
    }
}