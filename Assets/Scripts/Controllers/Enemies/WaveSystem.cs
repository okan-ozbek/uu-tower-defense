using System;
using System.Collections.Generic;
using Controllers.UI;
using Models;
using UnityEngine;
using Views;
using Random = UnityEngine.Random;

namespace Controllers.Enemies
{
    public class WaveSystem : MonoBehaviour
    {
        public static event Action OnWaveStarted;
        public static event Action OnWaveFinished;
        
        [SerializeField] private int multiplier = 2;
        [SerializeField] private List<GameObject> enemyPrefabs = new();

        private readonly List<GameObject> _enemies = new();

        private int _enemiesInWave; 
        private int _currentWave;
        private float _waveBudget;

        private void OnEnable()
        {
            EnemyController.OnEnemyDeath += HandleEnemyDestroyed;
            EnemyController.OnEnemyReachedEnd += HandleEnemyDestroyed;
            GameButtonController.OnStartWaveClicked += HandleStartWaveClicked;
        }

        private void OnDisable()
        {
            EnemyController.OnEnemyDeath -= HandleEnemyDestroyed;
            EnemyController.OnEnemyReachedEnd -= HandleEnemyDestroyed;
            GameButtonController.OnStartWaveClicked -= HandleStartWaveClicked;
        }
        
        private void HandleStartWaveClicked()
        {
            SetNextWaveDetails();
            GenerateEnemies();
        }

        private void SetNextWaveDetails()
        {
            _currentWave++;
            _waveBudget = _currentWave * multiplier;

            PurchaseEnemies();
        }

        private void GenerateEnemies()
        {
            const float spawnOffset = 1.0f;
            
            for (int i = 0; i < _enemies.Count; i++)
            {
                Vector2 spawnPosition = new Vector2(
                    PathController.Waypoints[0].position.x,
                    PathController.Waypoints[0].position.y - spawnOffset * i
                );
                GameObject instance = Instantiate(_enemies[i], spawnPosition, Quaternion.identity);
                instance.transform.SetParent(transform);
            }
            
            OnWaveStarted?.Invoke();
            _enemies.Clear();
        }

        private void PurchaseEnemies()
        {
            List<GameObject> availableEnemies = new List<GameObject>(enemyPrefabs);
            
            while(_waveBudget > 0 && availableEnemies.Count > 0)
            {
                GameObject enemy = availableEnemies[Random.Range(0, availableEnemies.Count)];
                if (enemy.GetComponent<Enemy>().Cost > _waveBudget)
                {
                    availableEnemies.Remove(enemy);
                    continue;
                }
                
                _enemies.Add(enemy);
                _waveBudget -= enemy.GetComponent<Enemy>().Cost;
            }
            
            _enemiesInWave = _enemies.Count;
        }
        
        private void HandleEnemyDestroyed(Enemy enemy)
        {
            _enemiesInWave--;
            if (_enemiesInWave == 0)
            {
                OnWaveFinished?.Invoke();
            }
        }
    }
}