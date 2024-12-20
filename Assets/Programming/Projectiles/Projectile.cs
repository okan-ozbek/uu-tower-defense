using System.Collections.Generic;
using System.Linq;
using Programming.Models;
using Programming.Utility.Enums;
using UnityEngine;

namespace Programming.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public bool isStatic;
        public bool isPiercing;
        public bool isExplosive;
        
        public float speed;
        public float damage;
        public float blastRadius;

        private readonly List<GameObject> _hitObjects = new();
        
        public void Update()
        {
            if (!isStatic)
            {
                Debug.Log("Weeee");
                transform.Translate(Vector2.up * (speed * Time.deltaTime));
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Enemy.ToString()))
            {
                if (isExplosive)
                {
                    var others = Physics2D.OverlapCircleAll(transform.position, blastRadius);
                    var enemies = (from enemy in others where enemy.CompareTag(Tags.Enemy.ToString()) select enemy.gameObject).ToList();
                    
                    foreach (var enemy in enemies)
                    {
                        enemy.GetComponent<EnemyModel>().Health.Value -= damage;
                    }
                }
                
                if (isPiercing && _hitObjects.Contains(other.gameObject) == false)
                {
                    _hitObjects.Add(other.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
                
                other.gameObject.GetComponent<EnemyModel>().Health.Value -= damage;
            }
        }
    }
}