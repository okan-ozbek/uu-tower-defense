using Settings.Programming.Configs;
using Settings.Programming.Enums;
using Settings.Programming.Factories;
using Settings.Programming.Player.Strategy;
using Settings.Programming.Stats;
using UnityEngine;

namespace Settings.Programming.Player
{
    public abstract class BaseObjectController : MonoBehaviour
    {
        [SerializeField] ObjectStatConfig objectStatConfig;

        public ObjectStats Stats;

        protected IAttackStrategy AttackStrategy;
        protected PathHandler PathHandler;

        protected void InitializeObject()
        {
            Stats = new ObjectStats(objectStatConfig, new StatMediator());
            PathHandler = new PathHandler(GameObject.FindWithTag(Tag.Path.ToString()).transform);
            AttackStrategy = new AttackStrategyFactory(this).GetStrategy(Stats.AttackType);
            LookAtTarget(null);
        }

        protected GameObject GetClosestEnemy()
        {
            GameObject closestEnemy = null;
            float closestDistance = float.MaxValue;
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, Stats.Range.GetCurrentValue());
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.CompareTag(Tag.Enemy.ToString()))
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

        public Transform GetClosestWaypoint()
        {
            return PathHandler.GetClosestWaypoint(new Vector2(transform.position.x, transform.position.y));
        }

        protected void LookAtTarget(GameObject target)
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
            UnityEngine.Gizmos.DrawWireSphere(transform.position, Stats.Range.GetCurrentValue());
        }
    }
}