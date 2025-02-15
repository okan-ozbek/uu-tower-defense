﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers.UI;
using Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Utility;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

namespace Controllers.Towers
{
    public class TowerPlacementController : MonoBehaviour
    {
        public static event Action<Tower> OnTowerPlaced;
        public static bool IsInteractable;
        
        [SerializeField] private GameObject placeholder;
        [SerializeField] private float invisibilitySeconds = 0.3f;
        [SerializeField] private float minDistance = 3f;
        [SerializeField] private GameObject parent;
        
        private GameObject _selectedTowerPrefab;
        private readonly List<GameObject> _placedTowers = new();
        
        private void OnEnable()
        {
            ShopController.OnShopTowerClicked += HandleShopTowerClicked;
            GameButtonController.OnTowerSellClicked += HandleTowerSellClicked;
        }

        private void OnDisable()
        {
            ShopController.OnShopTowerClicked -= HandleShopTowerClicked;
            GameButtonController.OnTowerSellClicked -= HandleTowerSellClicked;
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
                Vector2 closestWaypoint = PathController.GetClosestWaypoint(placeholder.transform.position);
                Vector2 direction = closestWaypoint - (Vector2)transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
                
                GameObject instance = Instantiate(_selectedTowerPrefab, placeholder.transform.position, Quaternion.Euler(0.0f, 0.0f, angle));
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
            bool isOverUI = EventSystem.current.IsPointerOverGameObject();
            
            return PathController.InbetweenWaypoints(mousePosition) == false && nearTower == false && isOverUI == false;
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