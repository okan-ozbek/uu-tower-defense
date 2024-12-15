using Settings.Programming.Configs;
using Settings.Programming.Enums;
using Settings.Programming.Factories;
using Settings.Programming.Player.Strategy;
using Settings.Programming.Stats;
using UnityEngine;

namespace Settings.Programming.Player
{
    public class ObjectController : MonoBehaviour
    {
        [SerializeField] ObjectStatConfig objectStatConfig;

        public ObjectStats Stats;

        private IAttackStrategy _attackStrategy;
        private PathHandler _pathHandler;
        private Vector3 _defaultRotation;

        private void Awake()
        {
            Stats = new ObjectStats(objectStatConfig, new StatMediator());
            _attackStrategy = (new AttackStrategyFactory(Stats)).GetAttack(objectStatConfig.attackType);
            _pathHandler = new PathHandler(GameObject.FindWithTag(Tag.Path.ToString()).transform);
            LookAt(null);
        }
        
        private void FixedUpdate()
        {
            GameObject closestEnemy = GetClosestEnemy();
            LookAt(closestEnemy);
            _attackStrategy.Shoot(closestEnemy);
            
            if (closestEnemy)
                Debug.DrawLine(transform.position, closestEnemy.transform.position, Color.green);
        }

        private GameObject GetClosestEnemy()
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

        private void LookAt(GameObject target)
        {
            Transform lookAt = (target) 
                ? target.transform 
                : _pathHandler.GetClosestWaypoint(new Vector2(transform.position.x, transform.position.y));
            
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