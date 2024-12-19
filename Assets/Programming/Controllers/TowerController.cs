using Programming.Entities.Enums;
using Programming.Entities.Factories;
using Programming.Entities.Handlers;
using Programming.Entities.Stats;
using Programming.Models;
using Programming.Utility.Enums;
using UnityEngine;

namespace Programming.Controllers
{
    [RequireComponent(
        requiredComponent: typeof(TowerModel)
    )]
    public class TowerController : Controller<TowerModel>
    {
        private AbilityStrategyFactory _abilityStrategyFactory;
        private WaypointHandler _waypointHandler;

        protected override void Awake()
        {
            base.Awake();
            
            _waypointHandler = new WaypointHandler(GameObject.FindWithTag(Tags.Path.ToString()).transform);
            _abilityStrategyFactory = new AbilityStrategyFactory(this);
            
            LookAtTarget(null);
        }

        private void Update()
        {
            UpdateAbilityStatsCooldownTime();
            
            GameObject closestEnemy = GetClosestEnemy();
            LookAtTarget(closestEnemy);
            
            if (closestEnemy)
            {
                foreach (AbilityStat abilityStat in model.AbilityStats)
                {
                    if (abilityStat.OnCooldown() == false)
                    {
                        _abilityStrategyFactory.GetStrategy(AbilityType.Hitscan).Use(closestEnemy, abilityStat);
                    }
                }

                Debug.DrawLine(transform.position, closestEnemy.transform.position, Color.red);
            }
        }

        private void UpdateAbilityStatsCooldownTime()
        {
            foreach (AbilityStat abilityStat in model.AbilityStats)
            {
                abilityStat.UpdateCooldownTime();
            }
        }

        private List<GameObject> GetEnemies()
        {
            List<GameObject> enemies = new List<GameObject>();
            
            // ReSharper disable once Unity.PreferNonAllocApi
            var colliders = Physics2D.OverlapCircleAll(transform.position, model.Range);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag(Tags.Enemy.ToString()))
                {
                    enemies.Add(collider.gameObject);
                }
            }

            return enemies;
        }

        private GameObject GetClosestEnemy()
        {
            GameObject closestEnemy = null;
            float closestDistance = float.MaxValue;
            
            List<GameObject> enemies = GetEnemies();

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

        private Transform GetClosestWaypoint()
        {
            return _waypointHandler.GetClosestWaypoint(new Vector2(transform.position.x, transform.position.y));
        }

        private void LookAtTarget(GameObject target)
        {
            Transform lookAt = (target)
                ? target.transform
                : GetClosestWaypoint();
            
            if (lookAt)
            {
                Vector3 direction = lookAt.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }

        private void OnDrawGizmos()
        {
            UnityEngine.Gizmos.color = Color.blue;
            UnityEngine.Gizmos.DrawWireSphere(transform.position, model.Range);
        }
    }
}