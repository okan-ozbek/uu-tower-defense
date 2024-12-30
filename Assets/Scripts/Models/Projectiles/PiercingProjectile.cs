using Configs.Projectiles;
using UnityEngine;
using Utility;

namespace Models.Projectiles
{
    public class PiercingProjectile : Projectile
    {
        [SerializeField] private PiercingProjectileConfig config;

        public Stat<int> MaxTargets;
        
        protected override void Start()
        {
            Speed = new Stat<float>(config.speed);
            Damage = new Stat<float>(config.damage);
            MaxTargets = new Stat<int>(config.maxTargets);
        }
    }
}