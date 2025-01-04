using System;
using System.Collections;
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
        private Color _startColor;
        private Transform _startTransform;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            _startColor = _spriteRenderer.color;
            _startTransform = transform;
            
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
            
            StartCoroutine(OnHit());
        }

        private void Death()
        {
            OnEnemyDeath?.Invoke(Model);
            Destroy(gameObject);
        }

        private IEnumerator OnHit()
        {
            _spriteRenderer.color = Color.white;
            transform.localScale *= 1.1f;
            
            yield return new WaitForSeconds(0.1f);
            
            if (Model.Health.Value <= 0)
            {
                Death();
            }
            
            _spriteRenderer.color = _startColor;
            transform.localScale = _startTransform.localScale;
        }
    }
}