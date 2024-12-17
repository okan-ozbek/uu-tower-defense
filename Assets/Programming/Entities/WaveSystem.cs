using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Programming.Enemies
{
    [Serializable]
    public class EnemySpecification
    {
        public GameObject prefab;
        public int cost;
    }
    
    public class WaveSystem : MonoBehaviour
    {
        [SerializeField] private int multiplier;
        [SerializeField] private List<EnemySpecification> enemies = new();

        private List<EnemySpecification> _spawnedEnemies = new();
        private int _currentWave;
        private int _budget;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetupNextWave();
                SpawnNextWave();
            }
        }
        
        private void SpawnNextWave()
        {
            const float offset = 1.0f;
            for (int index = 0; index < _spawnedEnemies.Count; index++)
            {
                Vector2 position = new Vector2(transform.position.x, transform.position.y - (index * offset));
                GameObject enemy = Instantiate(_spawnedEnemies[index].prefab, position, Quaternion.identity);
                enemy.transform.SetParent(transform);
            }
            
            _spawnedEnemies.Clear();
        }

        private void SetupNextWave()
        {
            _currentWave++;
            _budget = _currentWave * multiplier;
            
            AuctionEnemies(enemies);
        }

        private void AuctionEnemies(List<EnemySpecification> purchasableEnemies)
        {
            while (_budget > 0)
            {
                EnemySpecification specification = purchasableEnemies[Random.Range(0, enemies.Count)];

                if (specification.cost > _budget)
                {
                    purchasableEnemies.Remove(specification);
                    continue;
                }

                _budget -= specification.cost;
                _spawnedEnemies.Add(specification);
            }
        }
    }
}