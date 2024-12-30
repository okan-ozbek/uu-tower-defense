using System.Collections.Generic;
using Controllers.Enemies;
using Models.Projectiles;
using UnityEngine;

namespace Controllers.Projectiles
{
    [RequireComponent(typeof(PiercingProjectile))]
    public class PiercingProjectileController : ProjectileController<PiercingProjectile>
    {
        private readonly List<GameObject> _hitEnemies = new List<GameObject>();
        
        protected override void Move()
        {
            transform.position += transform.up * Model.Speed.Value * Time.deltaTime;
        }

        protected override void OnImpact(GameObject enemy)
        {
            if (_hitEnemies.Contains(enemy))
            {
                return;
            }
            
            enemy.GetComponent<EnemyController>().OnDamage(Model.Damage.Value);
            _hitEnemies.Add(enemy);
            
            if (_hitEnemies.Count == Model.MaxTargets.Value)
            {
                Destroy(gameObject);
            }
        }
        
        protected override void OnOutbound()
        {
            Destroy(gameObject);
        }
    }
}