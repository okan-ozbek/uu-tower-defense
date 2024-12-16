using Programming.Enums;
using Programming.Models;
using Programming.Pathfinding;
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
        private WaypointContainer _waypointContainer;
        private GameController _gameController;
        private Transform _path;

        protected override void Awake()
        {
            base.Awake();

            _gameController = GameObject.FindWithTag(Tags.GameController.ToString()).GetComponent<GameController>();
            _path = GameObject.FindWithTag(Tags.Path.ToString()).transform;
            _waypointContainer = new WaypointContainer(this, _path);
        }

        private void Update()
        {
            _waypointContainer.ProcessWaypoints();
            
            if (_waypointContainer.ReachedLastWaypoint())
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
    }
}