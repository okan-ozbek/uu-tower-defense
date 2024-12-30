﻿using System;
using Controllers.Enemies;
using Controllers.Towers;
using Controllers.UI;
using Models;
using UnityEngine;

namespace Controllers
{
    public class GameController : Controller<Game>
    {
        public static event Action<float> OnTowerSelectedUpdateMoney;

        protected override void Subscribe()
        {
            EnemyController.OnEnemyDeath += HandleEnemyDeath;
            EnemyController.OnEnemyReachedEnd += HandleEnemyReachedEnd;
            TowerPlacementController.OnTowerPlaced += HandleTowerPlaced;
            MouseSelectionController.OnTowerSelected += HandleTowerSelected;
            ButtonController.OnTowerSellClicked += HandleTowerSellClicked;
            ButtonController.OnTowerIncreaseSpeedClicked += HandleTowerIncreaseSpeed;
            ButtonController.OnTowerIncreaseRangeClicked += HandleTowerIncreaseRange;
            ButtonController.OnTowerUpgradeClicked += HandleTowerUpgrade;
        }

        protected override void Unsubscribe()
        {
            EnemyController.OnEnemyDeath -= HandleEnemyDeath;
            EnemyController.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
            TowerPlacementController.OnTowerPlaced -= HandleTowerPlaced;
            MouseSelectionController.OnTowerSelected -= HandleTowerSelected;
            ButtonController.OnTowerSellClicked -= HandleTowerSellClicked;
            ButtonController.OnTowerIncreaseSpeedClicked -= HandleTowerIncreaseSpeed;
            ButtonController.OnTowerIncreaseRangeClicked -= HandleTowerIncreaseRange;
            ButtonController.OnTowerUpgradeClicked -= HandleTowerUpgrade;
        }

        private void HandleEnemyReachedEnd(Enemy enemy)
        {
            Model.Health.Value -= enemy.Damage.Value;
        }

        private void HandleEnemyDeath(Enemy enemy)
        {
            Model.Money.Value += enemy.Reward;
        }

        private void HandleTowerPlaced(Tower tower)
        {
            Model.Money.Value -= tower.Cost;
        }

        private void HandleTowerSellClicked(TowerController controller)
        {
            Model.Money.Value += controller.Model.Sell;
        }
        
        private void HandleTowerIncreaseRange(TowerController controller)
        {
            Model.Money.Value -= 15f;
        }

        private void HandleTowerIncreaseSpeed(TowerController controller)
        {
            Model.Money.Value -= 25f;
        }

        private void HandleTowerUpgrade(TowerController controller)
        {
            Model.Money.Value -= 100f;
        }

        private void HandleTowerSelected(TowerController controller)
        {
            OnTowerSelectedUpdateMoney?.Invoke(Model.Money.Value);
        }
    }
}