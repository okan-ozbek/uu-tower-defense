using UnityEngine;

namespace Settings.Programming.Enemies
{
    public class WaypointProcessor
    {
        private const float DistanceDeadzone = 0.1f;
        
        private readonly Transform _waypoint;

        public WaypointProcessor(Transform waypoint)
        {
            _waypoint = waypoint;
        }

        public void Process(Transform entity, float speed)
        {
            entity.position = Vector3.MoveTowards(entity.position, _waypoint.position, speed * Time.deltaTime);
        }
        
        public bool IsProcessing(Transform entity)
        {
            return (Vector3.Distance(entity.position, _waypoint.position) > DistanceDeadzone);
        }
    }
}