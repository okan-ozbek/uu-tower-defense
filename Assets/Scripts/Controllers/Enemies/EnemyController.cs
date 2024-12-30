using System;
using Models;
using UnityEngine;

namespace Controllers.Enemies
{
    public class EnemyController : Controller<Enemy>
    {
        public static event Action<Enemy> OnEnemyDeath;
        public static event Action<Enemy> OnEnemyReachedEnd;

        public bool titleScreenEnemy;
        
        private int _currentWaypointIndex;

        private void Start()
        {
            if (titleScreenEnemy)
            {
                _currentWaypointIndex = PathController.GetClosestWaypointIndex(transform.position);
            }
        }
        
        private void Update()
        {
            Move();
            ReachedEnd();
        }
        private void Move()
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                PathController.Waypoints[_currentWaypointIndex].position, 
                Model.Speed.Value * Time.deltaTime
            );
            
            if (PathController.CanRetrieveNextWaypoint(_currentWaypointIndex, transform.position))
            {
                _currentWaypointIndex++;
            }
        }

        private void ReachedEnd()
        {
            if (PathController.HasReachedTheEnd(_currentWaypointIndex, transform.position) && titleScreenEnemy)
            {
                _currentWaypointIndex = 0;
                return;
            }
            
            if (PathController.HasReachedTheEnd(_currentWaypointIndex, transform.position))
            {
                OnEnemyReachedEnd?.Invoke(Model);
                Death();
            }
        }
        
        public void OnDamage(float value)
        {
            Model.Health.Value -= value;
            if (Model.Health.Value <= 0)
            {
                OnEnemyDeath?.Invoke(Model);
                Death();
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}