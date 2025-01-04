using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class PathController : MonoBehaviour
    {
        public static Transform[] Waypoints;

        private void Awake()
        {
            Waypoints = new Transform[transform.childCount];
            
            for (int i = 0; i < Waypoints.Length; i++)
            {
                Waypoints[i] = transform.GetChild(i);
            }
        }
        
        public static bool CanRetrieveNextWaypoint(int index, Vector2 position)
        {
            bool isNotLastWaypoint = index < Waypoints.Length - 1;

            return HasReachedWaypoint(index, position) && isNotLastWaypoint;
        }
        
        public static bool HasReachedTheEnd(int index, Vector2 position)
        {
            bool isLastWaypoint = index == Waypoints.Length - 1;
            
            return HasReachedWaypoint(index, position) && isLastWaypoint;
        }
        
        public static bool HasReachedWaypoint(int index, Vector2 position)
        {
            return Vector2.Distance(position, Waypoints[index].position) <= 0.025f;
        }
        
        public static bool InbetweenWaypoints(Vector2 position)
        {
            const float margin = 0.5f;

            for (int i = 0; i < Waypoints.Length - 1; i++)
            {
                Vector2 waypointMin = new Vector2(
                    Mathf.Min(Waypoints[i].position.x, Waypoints[i + 1].position.x) - margin,
                    Mathf.Min(Waypoints[i].position.y, Waypoints[i + 1].position.y) - margin
                );
                Vector2 waypointMax = new Vector2(
                    Mathf.Max(Waypoints[i].position.x, Waypoints[i + 1].position.x) + margin,
                    Mathf.Max(Waypoints[i].position.y, Waypoints[i + 1].position.y) + margin
                );

                Vector2 positionMin = position - Vector2.one * margin;
                Vector2 positionMax = position + Vector2.one * margin;
                
                if (
                    (positionMin.x <= waypointMax.x && positionMax.x >= waypointMin.x) && 
                    (positionMin.y <= waypointMax.y && positionMax.y >= waypointMin.y)
                ) {
                    return true;
                }
            }

            return false;
        }
        
        public static Vector2 GetClosestWaypoint(Vector2 position)
        {
            int closestWaypointIndex = GetClosestWaypointIndex(position);
            
            return Waypoints[closestWaypointIndex].position;
        }

        public static int GetClosestWaypointIndex(Vector2 position)
        {
            int closestWaypointIndex = 0;
            float closestDistance = Vector2.Distance(position, Waypoints[closestWaypointIndex].position);

            for (int i = 1; i < Waypoints.Length; i++)
            {
                float distance = Vector2.Distance(position, Waypoints[i].position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestWaypointIndex = i;
                }
            }

            return closestWaypointIndex;
        }
        
        private void OnDrawGizmos()
        {
            if (Waypoints == null || Waypoints.Length == 0) return;

            const float margin = 0.5f;
            Gizmos.color = Color.blue;

            for (int i = 0; i < Waypoints.Length - 1; i++)
            {
                Vector2 min = new Vector2(
                    Mathf.Min(Waypoints[i].position.x, Waypoints[i + 1].position.x) - margin,
                    Mathf.Min(Waypoints[i].position.y, Waypoints[i + 1].position.y) - margin
                );
                Vector2 max = new Vector2(
                    Mathf.Max(Waypoints[i].position.x, Waypoints[i + 1].position.x) + margin,
                    Mathf.Max(Waypoints[i].position.y, Waypoints[i + 1].position.y) + margin
                );

                Vector2 size = max - min;
                Vector2 center = min + size / 2;

                Gizmos.DrawWireCube(center, size);
            }
        }
    }
}