using Programming.Controllers;
using Programming.Entities.Handlers;
using Programming.Entities.Pathfinding;
using Programming.Enums;
using Programming.Models;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Programming.Entities
{
    public class TowerPlacer : MonoBehaviour
    {
        [SerializeField] private GameObject towerPlaceholder;
        [SerializeField] private float minDistance;

        private GameController _gameController;
        private WaypointHandler _waypointHandler;
        private TowerLocationHandler _towerLocationHandler;
        private Camera _camera;
        private GameObject _selectedTower;
        
        private void Awake()
        {
            _camera = Camera.main;
            _gameController = GameObject.FindWithTag(Tags.GameController.ToString()).GetComponent<GameController>();
            
            _towerLocationHandler = new TowerLocationHandler();
            _waypointHandler = new WaypointHandler(GameObject.FindWithTag(Tags.Path.ToString()).transform);

            ShopController.OnSelectedTower += SetSelectedTower;
        }

        private void OnDisable()
        {
            ShopController.OnSelectedTower -= SetSelectedTower;
        }

        private void Update()
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (_selectedTower)
            {
                towerPlaceholder.transform.position = mousePosition;
                
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    TowerPlacement(mousePosition);
                }
            }
            
            DrawDebugLines(mousePosition); // Debug only
        }
        
        private void TowerPlacement(Vector2 mousePosition)
        {
            if (CanPlaceTower(mousePosition))
            {
                towerPlaceholder.GetComponent<SpriteRenderer>().color = Color.green;
                towerPlaceholder.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.0f, 0.2f);

                if (Input.GetMouseButtonDown(0))
                {
                    GameObject tower = Instantiate(_selectedTower, mousePosition, Quaternion.identity);
                
                    _towerLocationHandler.Add(tower.transform);
                    _gameController.PurchaseTower(tower.GetComponent<TowerController>().model.Cost);
                }
            }
            else
            {
                towerPlaceholder.GetComponent<SpriteRenderer>().color = Color.red;
                towerPlaceholder.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 0.2f);
            }

            if (Input.GetMouseButtonDown(1))
            {
                SetSelectedTower(null);
            }
        }

        private bool CanPlaceTower(Vector2 mousePosition)
        {
            return InBudget() && OutOfRange(mousePosition);
        }

        private bool InBudget()
        {
            return _gameController.GetComponent<GameModel>().Money.Value >= _selectedTower.GetComponent<TowerModel>().Cost;
        }

        private bool OutOfRange(Vector2 mousePosition)
        {
            bool waypointsOutOfRange = (Vector2.Distance(mousePosition, _waypointHandler.GetClosestWaypoint(mousePosition).position) > minDistance);
            bool placedObjectsOutOfRange = (_towerLocationHandler.PlacedTowers <= 0) || (Vector2.Distance(mousePosition, _towerLocationHandler.GetClosestPlacedTower(mousePosition).position) > minDistance);
            
            return waypointsOutOfRange && placedObjectsOutOfRange;
        }

        private void SetSelectedTower(GameObject tower)
        {
            towerPlaceholder.SetActive(tower);
            if (tower)
            {
                towerPlaceholder.transform.GetChild(0).transform.localScale = new Vector2(
                    tower.GetComponent<TowerModel>().Range * 2.0f,
                    tower.GetComponent<TowerModel>().Range * 2.0f
                );
            }
            else
            {
                towerPlaceholder.transform.GetChild(0).transform.localScale = Vector2.one;
            }
            
            _selectedTower = tower;
        }

        private void DrawDebugLines(Vector2 mousePosition)
        {
            Color waypointColor = OutOfRange(mousePosition) ? Color.green : Color.red;
            Debug.DrawLine(mousePosition, _waypointHandler.GetClosestWaypoint(mousePosition).position, waypointColor);
            if (_towerLocationHandler.PlacedTowers > 0)
            {
                Color objectColor = OutOfRange(mousePosition) ? Color.green : Color.red;
                Debug.DrawLine(mousePosition, _towerLocationHandler.GetClosestPlacedTower(mousePosition).position, objectColor);
            }
        }
    }
}