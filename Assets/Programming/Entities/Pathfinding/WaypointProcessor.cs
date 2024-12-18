using UnityEngine;

namespace Programming.Entities.Pathfinding
{
    public class WaypointProcessor
    {
        private const float DistanceDeadzone = 0.1f;
        
        public Transform Transform { get; }

        public WaypointProcessor(Transform waypoint)
        {
            Transform = waypoint;
        }

        public void Process(Transform entity, float speed)
        {
            entity.position = Vector3.MoveTowards(entity.position, Transform.position, speed * Time.deltaTime);
        }
        
        public bool IsProcessing(Transform entity)
        {
            return (Vector3.Distance(entity.position, Transform.position) > DistanceDeadzone);
        }
    }
}