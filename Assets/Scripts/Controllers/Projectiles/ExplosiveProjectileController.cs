using System;
using System.Collections;
using System.Collections.Generic;
using Controllers.Enemies;
using Enums;
using Models.Projectiles;
using UnityEngine;

namespace Controllers.Projectiles
{
    [RequireComponent(typeof(ExplosiveProjectile))]
    public class ExplosiveProjectileController : ProjectileController<ExplosiveProjectile>
    {
        [SerializeField] private GameObject explosiveProjectileBlast;
        
        private bool _explosionSpawned;
        
        protected override void Move()
        {
            transform.position += transform.up * Model.Speed.Value * Time.deltaTime;
        }

        protected override void OnImpact(GameObject enemy)
        {
            if (_explosionSpawned == false)
            {
                GameObject instance = Instantiate(explosiveProjectileBlast, transform.position, Quaternion.identity);
                instance.transform.localScale = Vector2.one * (Model.Radius.Value * 2.0f);
                _explosionSpawned = true;
            }
            
            foreach (GameObject target in GetTargets())
            {
                target.GetComponent<EnemyController>().OnDamage(Model.Damage.Value);
            }
            
            Destroy(gameObject);
        }
        
        protected override void OnOutbound()
        {
            Destroy(gameObject);
        }

        private List<GameObject> GetTargets()
        {
            List<GameObject> list = new();
            Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, Model.Radius.Value);
            
            Array.Sort(targets, (Collider2D a, Collider2D b) => 
                Vector2.Distance(transform.position, a.transform.position).CompareTo(Vector2.Distance(transform.position, b.transform.position))
            );
            
            foreach (Collider2D target in targets)
            {
                if (list.Count == Model.MaxTargets.Value)
                {
                    break;
                }
                
                if (target.CompareTag(Tags.Enemy.ToString()))
                {
                    list.Add(target.gameObject);
                }
            }

            return list;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, Model.Radius.Value);
        }
    }
}