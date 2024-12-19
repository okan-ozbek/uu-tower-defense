using Programming.Entities.Enums;
using UnityEngine;

namespace Programming.Configs
{
    public class ProjectileAbilityConfig : AbstractAbilityConfig
    {
        public readonly AbilityType AbilityType = AbilityType.Projectile;

        public float projectileSpeed;
        public GameObject projectilePrefab;
    }
}