using System.Linq;
using Programming.Enums;
using Programming.Models;
using Programming.Object.Enums;
using Programming.Pathfinding;
using Programming.Stats;
using Programming.Towers.Factories;
using Programming.Towers.Strategies;
using UnityEngine;

namespace Programming.Controllers
{
    [RequireComponent(
        requiredComponent: typeof(TowerModel)
    )]
    public class TowerController : Controller<TowerModel>
    {
        private AbilityStrategyFactory _abilityStrategyFactory;
        private WaypointContainer _waypointContainer;

        protected override void Awake()
        {
            base.Awake();
            
            _waypointContainer = new WaypointContainer(GameObject.FindWithTag(Tags.Path.ToString()).transform);
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
                if (abilityStat.OnCooldown() == false)
                {
                    Debug.Log($"Attack stat {abilityStat.AbilityType} is off cooldown.");
                }
            }
        }

        private GameObject GetClosestEnemy()
        {
            GameObject closestEnemy = null;
            float closestDistance = float.MaxValue;
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, model.Range.Value);
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.CompareTag(Tags.Enemy.ToString()))
                {
                    float distance = Vector2.Distance(transform.position, enemy.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = enemy.gameObject;
                        closestEnemy.GetComponent<SpriteRenderer>().color = Color.blue;
                    }
                }
            }

            return closestEnemy;
        }

        private Transform GetClosestWaypoint()
        {
            return _waypointContainer.GetClosestWaypoint(new Vector2(transform.position.x, transform.position.y));
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
            UnityEngine.Gizmos.DrawWireSphere(transform.position, model.Range.Value);
        }
    }
}