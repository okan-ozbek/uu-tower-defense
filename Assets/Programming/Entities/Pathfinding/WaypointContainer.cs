using System.Collections.Generic;
using System.Linq;
using Programming.Controllers;
using UnityEngine;

namespace Programming.Entities.Pathfinding
{
    public class WaypointContainer
    {
        private readonly Transform _path;
        private readonly List<WaypointProcessor> _waypoints = new();
        private int _index;

        private readonly EnemyController _controller;

        public WaypointContainer(Transform path)
        {
            _path = path;
            PopulateWaypoints();
        }
        
        public WaypointContainer(EnemyController controller, Transform path)
        {
            _path = path;
            _controller = controller;

            PopulateWaypoints();
        }

        private void PopulateWaypoints()
        {
            foreach (Transform waypoint in _path)
            {
                _waypoints.Add(new WaypointProcessor(waypoint));
            }

            _index = 0;
        }

        public void ProcessWaypoints()
        {
            if (_controller == false)
            {
                return;
            }
            
            _waypoints[_index].Process(_controller.transform, _controller.model.Speed.Value);

            if (CanIncreaseIndex())
            {
                _index++;
            }
        }

        public bool ReachedLastWaypoint()
        {
            return (_index == _waypoints.Count - 1 && _waypoints[_index].IsProcessing(_controller.transform) == false);
        }

        public Transform GetClosestWaypoint(Vector2 position)
        {
            return _waypoints.OrderBy(waypoint => Vector2.Distance(waypoint.Transform.position, position)).First().Transform;
        }

        private bool CanIncreaseIndex()
        {
            return (_waypoints[_index].IsProcessing(_controller.transform) == false && (_index >= 0 && _index < _waypoints.Count - 1));
        }
    }
}