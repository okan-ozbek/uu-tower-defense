using Configs.Projectiles;
using UnityEngine;
using Utility;

namespace Models.Projectiles
{
    public class ExplosiveProjectile : Projectile
    {
        [SerializeField] private ExplosiveProjectileConfig config;

        public Stat<int> MaxTargets;
        public Stat<float> Radius;
        
        protected override void Start()
        {
            Speed = new Stat<float>(config.speed);
            Damage = new Stat<float>(config.damage);
            MaxTargets = new Stat<int>(config.maxTargets);
            Radius = new Stat<float>(config.radius);
        }
    }
}