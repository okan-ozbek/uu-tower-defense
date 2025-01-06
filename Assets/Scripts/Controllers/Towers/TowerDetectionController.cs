using System;
using System.Collections.Generic;
using Enums;
using Models;
using UnityEngine;

namespace Controllers.Towers
{
    public class TowerDetectionController : Controller<Tower>
    {
        public static event Action<GameObject, TowerController> OnTargetChanged;
        
        private GameObject _currentTarget;
        private GameObject _previousTarget;
        
        private void Update()
        {
            _currentTarget = GetTarget();
            OnTargetChanged?.Invoke(_currentTarget, GetComponent<TowerController>());
        }
        
        private List<GameObject> GetEnemiesInRange()
        {
            List<GameObject> enemyList = new();
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, Model.Range.Value);
            
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.CompareTag(Tags.Enemy.ToString()))
                {
                    enemyList.Add(enemy.gameObject);
                }
            }

            return enemyList;
        }

        private GameObject GetTarget()
        {
            GameObject target = null;
            float closestDistance = float.MaxValue;
            
            foreach (GameObject enemy in GetEnemiesInRange())
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = enemy;
                }
            }

            return target;
        }
    }
}