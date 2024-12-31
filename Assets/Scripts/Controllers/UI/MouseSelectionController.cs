using System;
using Controllers.Towers;
using Enums;
using UnityEngine;
using UnityEngine.EventSystems;
using Utility;

namespace Controllers.UI
{
    public class MouseSelectionController : MonoBehaviour
    {
        public static event Action<TowerController> OnTowerSelected;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }
    
        public void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 100.0f);
        
            GetStatsPanel(hit);
        }

        private void GetStatsPanel(RaycastHit2D hit)
        {
            if (
                UserInput.OnLeftMouseClick() && 
                hit.collider && 
                hit.collider.CompareTag(Tags.Tower.ToString()) &&
                TowerPlacementController.IsInteractable
            ) {
                OnTowerSelected?.Invoke(hit.collider.GetComponent<TowerController>());
            }
        }
    }
}