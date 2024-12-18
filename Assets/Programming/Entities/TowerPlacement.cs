using Programming.Controllers;
using Programming.Data;
using UnityEngine;

namespace Programming.Entities
{
    public class TowerPlacement : MonoBehaviour
    {
        private TowerPlacementData _data;
        
        private void Awake()
        {
            _data = new TowerPlacementData(this);
            
            ShopController.OnSelectedTower += SetSelectedTower;
        }

        private void OnDisable()
        {
            ShopController.OnSelectedTower -= SetSelectedTower;
        }

        private void Update()
        {
            Vector2 mousePosition = _data.Camera.ScreenToWorldPoint(Input.mousePosition);
            
            Place(mousePosition);
            Unselect();
            
            _data.TowerPlaceholder.Hover(_data.CanPlaceTower(mousePosition));
            
            DrawDebug(mousePosition);
        }
        
        private void Place(Vector2 mousePosition)
        {
            if (_data.SelectedTower == false)
            {
                return;
            }

            _data.TowerPlaceholder.Move(mousePosition);
            
            if (_data.CanInstantiateTower(mousePosition))
            {
                GameObject instance = Instantiate(_data.SelectedTower, mousePosition, Quaternion.identity);
            
                _data.TowerLocationHandler.Add(instance.transform);
                _data.GameController.PurchaseTower(instance.GetComponent<TowerController>().model.Cost);
            }
        }

        private void Unselect()
        {
            if (Input.GetMouseButtonDown(1))
            {
                SetSelectedTower(null);
            }
        }
        
        private void SetSelectedTower(GameObject tower)
        {
            _data.TowerPlaceholder.Set(tower);
            _data.SelectedTower = tower;
        }
        
        private void DrawDebug(Vector2 mousePosition)
        {
            Color waypointColor = _data.OutOfRange(mousePosition) ? Color.green : Color.red;
            Debug.DrawLine(mousePosition, _data.WaypointHandler.GetClosestWaypoint(mousePosition).position, waypointColor);
            if (_data.TowerLocationHandler.PlacedTowers > 0)
            {
                Color objectColor = _data.OutOfRange(mousePosition) ? Color.green : Color.red;
                Debug.DrawLine(mousePosition, _data.TowerLocationHandler.GetClosestPlacedTower(mousePosition).position, objectColor);
            }
        }
    }
}