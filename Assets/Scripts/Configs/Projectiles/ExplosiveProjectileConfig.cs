using UnityEngine;

namespace Configs.Projectiles
{
    [CreateAssetMenu(fileName = "ExplosiveProjectile", menuName = "Projectiles/ExplosiveProjectile")]
    public class ExplosiveProjectileConfig : ProjectileConfig
    {
        public int maxTargets;
        public float radius;
    }
}