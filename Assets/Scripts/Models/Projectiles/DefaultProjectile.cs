using Configs.Projectiles;
using UnityEngine;
using Utility;

namespace Models.Projectiles
{
    public class DefaultProjectile : Projectile
    {
        [SerializeField] private DefaultProjectileConfig config;

        protected override void Start()
        {
            Speed = new Stat<float>(config.speed);
            Damage = new Stat<float>(config.damage);
        }
    }
}