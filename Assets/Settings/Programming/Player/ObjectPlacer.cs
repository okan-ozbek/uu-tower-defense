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
        
        private PathHandler _pathHandler;
        private PlacedObjectHandler _placedObjectHandler;
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
            _placedObjectHandler = new PlacedObjectHandler();
            _pathHandler = new PathHandler(GameObject.FindWithTag(Tag.Path.ToString()).transform);
        }

        private void Update()
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            if (OutOfRange(mousePosition) && Input.GetMouseButtonDown(0))
            {
                GameObject placedObject = Instantiate(temp, mousePosition, Quaternion.identity);
                _placedObjectHandler.Add(placedObject.transform);
            }
            
            DrawDebugLines(mousePosition); // Debug only
        }

        private bool OutOfRange(Vector2 mousePosition)
        {
            bool waypointsOutOfRange = (Vector2.Distance(mousePosition, _pathHandler.GetClosestWaypoint(mousePosition).position) > minDistance);
            bool placedObjectsOutOfRange = (_placedObjectHandler.PlacedObjects <= 0) || (Vector2.Distance(mousePosition, _placedObjectHandler.GetClosestPlacedObject(mousePosition).position) > minDistance);
            
            return waypointsOutOfRange && placedObjectsOutOfRange;
        }

        private void DrawDebugLines(Vector2 mousePosition)
        {
            Color waypointColor = OutOfRange(mousePosition) ? Color.green : Color.red;
            Debug.DrawLine(mousePosition, _pathHandler.GetClosestWaypoint(mousePosition).position, waypointColor);
            if (_placedObjectHandler.PlacedObjects > 0)
            {
                Color objectColor = OutOfRange(mousePosition) ? Color.green : Color.red;
                Debug.DrawLine(mousePosition, _placedObjectHandler.GetClosestPlacedObject(mousePosition).position, objectColor);
            }
        }
    }
}