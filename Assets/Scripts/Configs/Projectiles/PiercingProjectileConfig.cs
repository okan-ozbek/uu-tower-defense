using UnityEngine;

namespace Configs.Projectiles
{
    [CreateAssetMenu(fileName = "PiercingProjectile", menuName = "Projectiles/PiercingProjectile")]
    public class PiercingProjectileConfig : ProjectileConfig
    {
        public int maxTargets;
    }
}