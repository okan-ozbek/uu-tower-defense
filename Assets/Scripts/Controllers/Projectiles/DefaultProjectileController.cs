using Controllers.Enemies;
using Models.Projectiles;
using UnityEngine;

namespace Controllers.Projectiles
{
    [RequireComponent(typeof(DefaultProjectile))]
    public class DefaultProjectileController : ProjectileController<DefaultProjectile>
    {
        protected override void Move()
        {
            transform.position += transform.up * Model.Speed.Value * Time.deltaTime;
        }

        protected override void OnImpact(GameObject enemy)
        {
            enemy.GetComponent<EnemyController>().OnDamage(Model.Damage.Value);
            Destroy(gameObject);
        }
        
        protected override void OnOutbound()
        {
            Destroy(gameObject);
        }
    }
}