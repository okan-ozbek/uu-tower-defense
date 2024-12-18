﻿using System.Collections;
using Programming.Entities.Enums;
using Programming.Entities.Handlers;
using Programming.Entities.Pathfinding;
using Programming.Enums;
using Programming.Models;
using UnityEngine;

namespace Programming.Controllers
{
    [RequireComponent(
        requiredComponent:  typeof(CircleCollider2D), 
        requiredComponent2: typeof(Rigidbody2D), 
        requiredComponent3: typeof(EnemyModel)
    )]
    public class EnemyController : Controller<EnemyModel>
    {
        private WaypointHandler _waypointHandler;
        private GameController _gameController;
        private Transform _path;

        protected override void Awake()
        {
            base.Awake();

            _gameController = GameObject.FindWithTag(Tags.GameController.ToString()).GetComponent<GameController>();
            _path = GameObject.FindWithTag(Tags.Path.ToString()).transform;
            _waypointHandler = new WaypointHandler(this, _path);
        }

        private void Update()
        {
            _waypointHandler.ProcessWaypoints();
            
            if (_waypointHandler.ReachedLastWaypoint())
            {
                _gameController.HandleFinishedEvent(model.Damage.Value);
                Destroy(gameObject);
            }
            
            if (model.Health.Value <= 0)
            {
                _gameController.HandleDeathEvent(model.Money.Value);
                Destroy(gameObject);
            }
        }

        public void SetStatusEffect(StatType statType, float value, float duration)
        {
            float baseValue = model.GetStat(statType).Value;
            model.GetStat(statType).Value += value;

            StartCoroutine(RemoveStatusEffect(statType, baseValue, duration));
        }

        private IEnumerator RemoveStatusEffect(StatType statType, float baseValue, float duration)
        {
            yield return new WaitForSeconds(duration);
            model.GetStat(statType).Value = baseValue;
        }
    }
}