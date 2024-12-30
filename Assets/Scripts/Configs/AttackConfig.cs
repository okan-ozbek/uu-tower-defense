using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "AttackConfig", menuName = "Configs/AttackConfig")]
    public class AttackConfig : ScriptableObject
    {
        [Header("Attack settings")]
        public GameObject projectilePrefab;
        public AttackPatternType attackPatternType;
        public int count;
        public float burstCooldown;
    }
}