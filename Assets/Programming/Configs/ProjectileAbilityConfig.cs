using Programming.Abilities.Enums;
using Programming.Entities.Enums;
using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "ProjectileAbilityConfig", menuName = "Settings/Abilities/ProjectileAbilityConfig")]
    public class ProjectileAbilityConfig : AbstractAbilityConfig
    {
        public readonly AbilityType AbilityType = AbilityType.Projectile;

        public float projectileSpeed;
        public GameObject projectilePrefab;
    }
}