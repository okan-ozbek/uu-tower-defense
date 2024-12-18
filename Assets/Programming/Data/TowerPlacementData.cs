using Programming.Controllers;
using Programming.Entities;
using Programming.Entities.Handlers;
using Programming.Models;
using Programming.Utility.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Programming.Data
{
    public class TowerPlacementData
    {
        private const float MinDistance = 0.75f;
        
        public readonly Camera Camera;
        public GameObject SelectedTower;

        public readonly GameController GameController;
        public readonly WaypointHandler WaypointHandler;
        public readonly TowerLocationHandler TowerLocationHandler;
        public readonly TowerPlaceholder TowerPlaceholder;

        public TowerPlacementData(TowerPlacement parent)
        {
            Camera = Camera.main;
            SelectedTower = null;
            
            GameController = GameObject.FindWithTag(Tags.GameController.ToString()).GetComponent<GameController>();
            WaypointHandler = new WaypointHandler(GameObject.FindWithTag(Tags.Path.ToString()).transform);
            TowerLocationHandler = new TowerLocationHandler();
            TowerPlaceholder = new TowerPlaceholder(parent.transform.GetChild(0).gameObject);
        }
        
        #region Booleans
        public bool CanPlaceTower(Vector2 mousePosition)
        {
            return SelectedTower && InBudget() && OutOfRange(mousePosition);
        }
        
        public bool CanInstantiateTower(Vector2 mousePosition)
        {
            return CanPlaceTower(mousePosition) && Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false;
        }
        
        public bool OutOfRange(Vector2 mousePosition)
        {
            bool notInWaypointsDistance = InDistance(mousePosition, WaypointHandler.GetClosestWaypoint(mousePosition)) == false;
            bool notInPlacedObjectsDistance = InDistance(mousePosition, TowerLocationHandler.GetClosestPlacedTower(mousePosition)) == false;
            bool towersPlaced = TowerLocationHandler.PlacedTowers > 0;
            
            return notInWaypointsDistance && (notInPlacedObjectsDistance || towersPlaced);
        }

        private bool InBudget()
        {
            return GameController.model.Money.Value >= SelectedTower.GetComponent<TowerModel>().Cost;
        }
        
        private bool InDistance(Vector2 mousePosition, Transform target)
        {
            if (target == false)
            {
                return false;
            }
            
            return Vector2.Distance(mousePosition, target.position) <= MinDistance;
        }
        #endregion
    }
}