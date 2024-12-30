using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers.UI;
using Models;
using UnityEngine;
using UnityEngine.UIElements;
using Utility;

namespace Controllers.Towers
{
    public class TowerPlacementController : MonoBehaviour
    {
        public static event Action<Tower> OnTowerPlaced;
        public static bool IsInteractable;
        
        [SerializeField] private GameObject placeholder;
        [SerializeField] private float invisibilitySeconds = 0.3f;
        [SerializeField] private float minDistance = 1.25f;
        [SerializeField] private GameObject parent;
        
        private GameObject _selectedTowerPrefab;
        private readonly List<GameObject> _placedTowers = new();
        
        private void OnEnable()
        {
            ShopController.OnShopTowerClicked += HandleShopTowerClicked;
            ButtonController.OnTowerSellClicked += HandleTowerSellClicked;
        }

        private void OnDisable()
        {
            ShopController.OnShopTowerClicked -= HandleShopTowerClicked;
            ButtonController.OnTowerSellClicked -= HandleTowerSellClicked;
        }

        private void Update()
        {
            Vector2 mousePosition = UserInput.MousePosition();
            
            PlaceholderMovement(mousePosition);
            PurchaseTower(mousePosition);
            CancelPurchaseTower();
            SetPlaceholderIndicationColor(mousePosition);
        }

        private void PlaceholderMovement(Vector2 mousePosition)
        {
            placeholder.transform.position = mousePosition;
        }
        
        private void PurchaseTower(Vector2 mousePosition)
        {
            if (_selectedTowerPrefab && UserInput.OnLeftMouseClick() && CanPlaceTower(mousePosition))
            {
                GameObject instance = Instantiate(_selectedTowerPrefab, placeholder.transform.position, Quaternion.identity);
                instance.transform.parent = parent.transform;
                
                OnTowerPlaced?.Invoke(instance.GetComponent<Tower>());
                _placedTowers.Add(instance);
                
                UnselectTower();
                StartCoroutine(TimeUntilInteractable());
            }
        }

        private void CancelPurchaseTower()
        {
            if (_selectedTowerPrefab && UserInput.OnRightMouseClick())
            {
                UnselectTower();
            }
        }

        private void UnselectTower()
        {
            _selectedTowerPrefab = null;
            placeholder.SetActive(false);
            IsInteractable = true;
        }

        private void SetPlaceholderIndicationColor(Vector2 mousePosition)
        {
            Color placeholderColor = (CanPlaceTower(mousePosition))
                ? Color.green
                : Color.red;
            
            Color placeholderRangeColor = new Color(placeholderColor.r, placeholderColor.g, placeholderColor.b, 0.2f);
            
            placeholder.GetComponent<SpriteRenderer>().color = placeholderColor;
            placeholder.transform.GetChild(0).GetComponent<SpriteRenderer>().color = placeholderRangeColor;
        }

        private bool CanPlaceTower(Vector2 mousePosition)
        {
            GameObject closestTower = _placedTowers.OrderBy(tower => Vector2.Distance(tower.transform.position, mousePosition)).FirstOrDefault();
            bool nearTower = closestTower && Vector2.Distance(closestTower.transform.position, mousePosition) <= minDistance;
            
            return PathController.InbetweenWaypoints(mousePosition) == false && nearTower == false;
        }

        private void HandleShopTowerClicked(GameObject towerPrefab)
        {
            IsInteractable = false;
            _selectedTowerPrefab = towerPrefab;
            
            placeholder.SetActive(true);
            placeholder.transform.GetChild(0).transform.localScale = new Vector2(
                _selectedTowerPrefab.GetComponent<Tower>().BaseRange * 2.0f, 
                _selectedTowerPrefab.GetComponent<Tower>().BaseRange * 2.0f
            );
        }
        
        private void HandleTowerSellClicked(TowerController towerController)
        {
            _placedTowers.Remove(towerController.gameObject);
        }
        
        private IEnumerator TimeUntilInteractable()
        {
            yield return new WaitForSeconds(invisibilitySeconds);
            
            IsInteractable = true;
        }
    }
}