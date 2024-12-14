using System.Collections.Generic;
using UnityEngine;

namespace Settings.Programming.Enemies.Pathfinding
{
    public class WaypointContainer
    {
        private readonly Transform _path;
        private readonly List<WaypointProcessor> _waypoints = new();
        private int _index;

        private readonly EnemyController _enemyController;

        public WaypointContainer(Transform path)
        {
            _path = path;
            PopulateWaypoints();
        }
        
        public WaypointContainer(EnemyController enemyController, Transform path)
        {
            _path = path;
            _enemyController = enemyController;

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
            if (_enemyController == false)
            {
                return;
            }
            
            _waypoints[_index].Process(_enemyController.transform, _enemyController.Stats.Speed.GetCurrentValue());

            if (CanIncreaseIndex())
            {
                _index++;
            }
        }

        public bool PassedFirstWaypoint()
        {
            return (_index > 0);
        }

        public bool ReachedLastWaypoint()
        {
            return (_index == _waypoints.Count - 1 && _waypoints[_index].IsProcessing(_enemyController.transform) == false);
        }
        
        private bool CanIncreaseIndex()
        {
            return (_waypoints[_index].IsProcessing(_enemyController.transform) == false &&(_index >= 0 && _index < _waypoints.Count - 1));
        }
    }
}