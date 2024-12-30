using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig")]
    public class TowerConfig : ScriptableObject
    {
        [Header("UI")] public Sprite icon;
        
        [Header("Attack settings")]
        public AttackPatternType attackPatternType;
        public int count;
        public float burstCooldown;
        
        [Header("Tower settings")]
        public float cost;
        public float range;
        public float cooldown;
        public bool isStationary;
    }
}