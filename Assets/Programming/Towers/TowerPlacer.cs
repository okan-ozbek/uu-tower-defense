using Programming.Controllers;
using Programming.Enums;
using Programming.Models;
using Programming.Object;
using Programming.Pathfinding;
using UnityEngine;

namespace Programming.Towers
{
    public class TowerPlacer : MonoBehaviour
    {
        public GameObject temp;
        
        [SerializeField] private float minDistance;

        private GameController _gameController;
        private WaypointContainer _waypointContainer;
        private TowerLocationContainer _towerLocationContainer;
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
            _gameController = GameObject.FindWithTag(Tags.GameController.ToString()).GetComponent<GameController>();
            _towerLocationContainer = new TowerLocationContainer();
            _waypointContainer = new WaypointContainer(GameObject.FindWithTag(Tags.Path.ToString()).transform);
        }

        private void Update()
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            PlaceObject(mousePosition);
            DrawDebugLines(mousePosition); // Debug only
        }
        
        private void PlaceObject(Vector2 mousePosition)
        {
            if (InBudget() && OutOfRange(mousePosition) && Input.GetMouseButtonDown(0))
            {
                GameObject placedObject = Instantiate(temp, mousePosition, Quaternion.identity);
                _towerLocationContainer.Add(placedObject.transform);
                _gameController.PurchaseTower(placedObject.GetComponent<TowerController>().model.Cost);
            }
        }

        private bool InBudget()
        {
            return _gameController.GetComponent<GameModel>().Money.Value >= temp.GetComponent<TowerModel>().Cost;
        }

        private bool OutOfRange(Vector2 mousePosition)
        {
            bool waypointsOutOfRange = (Vector2.Distance(mousePosition, _waypointContainer.GetClosestWaypoint(mousePosition).position) > minDistance);
            bool placedObjectsOutOfRange = (_towerLocationContainer.PlacedTowers <= 0) || (Vector2.Distance(mousePosition, _towerLocationContainer.GetClosestPlacedTower(mousePosition).position) > minDistance);
            
            return waypointsOutOfRange && placedObjectsOutOfRange;
        }

        private void DrawDebugLines(Vector2 mousePosition)
        {
            Color waypointColor = OutOfRange(mousePosition) ? Color.green : Color.red;
            Debug.DrawLine(mousePosition, _waypointContainer.GetClosestWaypoint(mousePosition).position, waypointColor);
            if (_towerLocationContainer.PlacedTowers > 0)
            {
                Color objectColor = OutOfRange(mousePosition) ? Color.green : Color.red;
                Debug.DrawLine(mousePosition, _towerLocationContainer.GetClosestPlacedTower(mousePosition).position, objectColor);
            }
        }
    }
}