using Programming.Entities.Enums;
using UnityEngine;

namespace Programming.Configs
{
    public abstract class AbstractAbilityConfig : ScriptableObject
    {
        public float range;
        public float damage;
        public float cooldown;
        public float count;

        public TargetType targetType;

    
    }
}