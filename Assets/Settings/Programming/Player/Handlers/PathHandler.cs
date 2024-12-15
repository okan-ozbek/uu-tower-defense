using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Settings.Programming.Player
{
    public class PathHandler
    {
        private readonly List<Transform> _waypoints = new();

        public PathHandler(Transform path)
        {
            foreach (Transform waypoint in path)
            {
                _waypoints.Add(waypoint);
            }
        }
        
        public Transform GetClosestWaypoint(Vector2 position)
        {
            return _waypoints.OrderBy(waypoint => Vector2.Distance(waypoint.position, position)).First();
        }
        
    }
}