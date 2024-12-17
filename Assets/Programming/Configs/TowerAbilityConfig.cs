using Programming.Entities.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "TowerAbilityConfig", menuName = "Settings/Configs/TowerAbilityConfig")]
    public class TowerAbilityConfig : ScriptableObject
    {
        public float value;
        public float cooldown;
        public AbilityType abilityType;
        public StatType statType;
    }
}