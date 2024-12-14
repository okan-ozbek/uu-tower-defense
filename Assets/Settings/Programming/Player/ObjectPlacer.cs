using System.Collections.Generic;
using System.Linq;
using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Player
{
    public class ObjectPlacer : MonoBehaviour
    {
        public GameObject temp;
        
        [SerializeField] private float minDistance;
        [SerializeField] private Transform path;

        private List<Transform> _waypoints;
        private List<Transform> _placedObjects;
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
            path = GameObject.FindWithTag(Tag.Path.ToString()).transform;
            
            _waypoints = new List<Transform>();
            
            foreach (Transform waypoint in path)
            {
                _waypoints.Add(waypoint);
            }
        }

        private void Update()
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 closestWaypoint = GetClosestWaypoint(mousePosition);
            Vector2 closestPlacedObject = GetClosestPlacedObject(mousePosition);
            
            if (OutOfRange(mousePosition, closestWaypoint, closestPlacedObject) && Input.GetMouseButtonDown(0))
            {
                Instantiate(temp, mousePosition, Quaternion.identity);
                _placedObjects.Add(temp.transform);
            }
            
            // Debug code
            Color color = OutOfRange(mousePosition, closestWaypoint, closestPlacedObject) ? Color.green : Color.red;
            Debug.DrawLine(mousePosition, closestWaypoint, color);
        }
        
        private Vector2 GetClosestWaypoint(Vector2 mousePosition)
        {
            return _waypoints.OrderBy(waypoint => Vector2.Distance(waypoint.position, mousePosition)).First().position;
        }

        private Vector2 GetClosestPlacedObject(Vector2 mousePosition)
        {
            // Returns null
            return _placedObjects.OrderBy(placedObject => Vector2.Distance(placedObject.position, mousePosition)).First().position;
        }

        private bool OutOfRange(Vector2 mousePosition, Vector2 closestWaypoint, Vector2 closestPlacedObject)
        {
            // Returns null because of the null reference exception in GetClosestPlacedObject
            return (Vector2.Distance(mousePosition, closestWaypoint) > minDistance) && (Vector2.Distance(mousePosition, closestPlacedObject) > minDistance);
        }
    }
}