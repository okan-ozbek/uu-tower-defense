using System.Collections.Generic;
using System.Linq;
using Programming.Entities.Handlers;
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
        private WaypointHandler _waypointHandler;

        protected override void Awake()
        {
            base.Awake();
            
            _waypointHandler = new WaypointHandler(GameObject.FindWithTag(Tags.Path.ToString()).transform);
            LookAtTarget(_waypointHandler.GetClosestWaypoint(transform.position).gameObject);
        }

        private void Update()
        {
            GameObject closestEnemy = GetClosestEnemy();
            LookAtTarget(closestEnemy);
            
            if (closestEnemy)
            {
                Debug.DrawLine(transform.position, closestEnemy.transform.position, Color.red);
            }
        }

        public List<GameObject> GetEnemies()
        {
            // ReSharper disable once Unity.PreferNonAllocApi
            var others = Physics2D.OverlapCircleAll(transform.position, model.Range);

            return (from other in others where other.CompareTag(Tags.Enemy.ToString()) select other.gameObject).ToList();
        }

        public GameObject GetClosestEnemy()
        {
            GameObject closestEnemy = null;
            float closestDistance = float.MaxValue;
            
            var enemies = GetEnemies();
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
            if (target == false)
            {
                return;
            }
            
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
         }

        private void OnDrawGizmos()
        {
            UnityEngine.Gizmos.color = Color.blue;
            UnityEngine.Gizmos.DrawWireSphere(transform.position, model.Range);
        }
    }
}