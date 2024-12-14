using Settings.Programming.Configs;
using Settings.Programming.Enemies;
using Settings.Programming.Enums;
using Settings.Programming.Stats;
using UnityEngine;

namespace Settings.Programming.Interactables
{
    [RequireComponent(typeof(Collider2D))]
    public class GooController : MonoBehaviour
    {
        public InteractableConfig config;
        private StatModifier _statModifier;

        private void Awake()
        {
            _statModifier = new StatModifier(
                config.modification,
                config.duration,
                config.statType,
                config.operatorType
            );
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag.Enemy.ToString()))
            {
                other.GetComponent<EnemyController>().Stats.Mediator.Add(_statModifier);
                Destroy(gameObject);
            }
        }
    }
}