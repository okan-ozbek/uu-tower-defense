using System.Collections.Generic;
using UnityEngine;

namespace Settings.Programming.Enemies.WaveSystem
{
    [System.Serializable]
    public class Enemy
    {
        public GameObject gameObject;
        public int cost;
    }
    
    public class WaveSpawner : MonoBehaviour
    {
        public int budgetMultiplier;
        public List<Enemy> enemies;

        private List<Enemy> _waveEnemies;
        private int _currentWave;
        private int _budget;

        private void Start()
        {
            _waveEnemies = new List<Enemy>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GenerateWave();
                SpawnWave();
            }
        }

        private void SpawnWave()
        {
            for (int index = 0; index < _waveEnemies.Count; index++)
            {
                Vector2 position = new Vector2(transform.position.x, transform.position.y - (index * 1.0f));
                GameObject enemy = Instantiate(_waveEnemies[index].gameObject, position, Quaternion.identity);
                enemy.transform.SetParent(transform);
            }
            
            _waveEnemies.Clear();
        }
        
        private void GenerateWave()
        {
            _currentWave++;
            _budget = _currentWave * budgetMultiplier;

            List<Enemy> affordableEnemies = enemies;
            while (_budget > 0)
            {
                Enemy enemy = affordableEnemies[Random.Range(0, enemies.Count)];
                
                if (enemy.cost > _budget)
                {
                    affordableEnemies.Remove(enemy);
                    continue;
                }
                
                _budget -= enemy.cost;
                _waveEnemies.Add(enemy);
            }
        }
    }
}