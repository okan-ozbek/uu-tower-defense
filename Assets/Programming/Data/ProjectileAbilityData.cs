using Programming.Configs;
using Programming.Entities.Enums;
using UnityEngine;

namespace Programming.Data
{
    public class ProjectileAbilityData : AbstractAbilityData
    { 
        public float ProjectileSpeed;
        public readonly GameObject ProjectilePrefab;
        
        public ProjectileAbilityData(ProjectileAbilityConfig config) : base(config)
        {
            ProjectilePrefab = config.projectilePrefab;
            ProjectileSpeed = config.projectileSpeed;
        }
    }
}