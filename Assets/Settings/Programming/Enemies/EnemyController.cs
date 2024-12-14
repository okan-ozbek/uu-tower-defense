using System;
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
