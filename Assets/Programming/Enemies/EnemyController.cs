using System;
using System.Collections;
using Settings.Programming.Configs;
using Settings.Programming.Enemies.Pathfinding;
using Settings.Programming.Enemies.States;
using Settings.Programming.Enums;
using Settings.Programming.Factories;
using Settings.Programming.Stats;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Programming.Enemies
{
    [RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform path;
        [SerializeField] private EnemyStatConfig statConfig;
        
        public EnemyBaseState State;
        public EnemyStateFactory Factory;
        public EnemyStats Stats;
        public WaypointContainer WaypointContainer;
        
        public static event Action OnFinished;
        public static event Action OnDeath;
        public event Action OnTakeDamage;

        private void Awake()
        {
            InitializeEnemy();
            InitializeStateMachine();
        }
        
        private void Update()
        {
            Stats.Mediator.Update(Time.deltaTime);
            WaypointContainer.ProcessWaypoints();
            State.Update();
        }

        private void InitializeEnemy()
        {
            Stats = new EnemyStats(statConfig, new StatMediator());
            path = GameObject.FindWithTag(Tag.Path.ToString()).transform;
            WaypointContainer = new WaypointContainer(this, path);
        }

        private void InitializeStateMachine()
        {
            Factory = new EnemyStateFactory(this);
            State = Factory.GetState(EnemyStateType.Start);
            State.Enter();
        }
        
        public void TakeDamage(float damage, OperatorType operatorType)
        {
            Stats.TakeDamage(damage, operatorType);
            StartCoroutine(HurtEffect());
            
            OnTakeDamage?.Invoke();
        }

        private IEnumerator HurtEffect()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color originalColor = spriteRenderer.color;
            
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.4f);
            spriteRenderer.color = originalColor;

        }
        
        public static void OnDeathEvent()
        {
            OnDeath?.Invoke();
        }
        
        public static void OnFinishedEvent()
        {
            OnFinished?.Invoke();
        }

        public void Destroy()
        {
            OnDeath = null;
            OnFinished = null;
            
            Destroy(gameObject);
        }
    }
}
