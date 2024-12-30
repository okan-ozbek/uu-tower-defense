using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig")]
    public class TowerConfig : ScriptableObject
    {
        [Header("UI")] public Sprite icon;
        
        [Header("Tower settings")]
        public float cost;
        public float range;
        public float cooldown;
        public bool isStationary;
        
        [Header("Upgrades")]
        public int maxRangeUpgrades;
        public int maxSpeedUpgrades;
        public int maxUpgradeUpgrades;
    }
}