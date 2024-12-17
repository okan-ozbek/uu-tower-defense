using Programming.Object.Enums;
using Programming.Stats;
using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "TowerAttackConfig", menuName = "Settings/Configs/TowerAttackConfig")]
    public class TowerAttackConfig : ScriptableObject
    {
        public float value;
        public float cooldown;
        public AttackType attackType;
        public StatType statType;
    }
}