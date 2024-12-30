using Controllers.Enemies;
using Controllers.Towers;
using Controllers.UI;
using Models;
using UnityEngine;

namespace Controllers
{
    public class GameController : Controller<Game>
    {
        protected override void Subscribe()
        {
            EnemyController.OnEnemyDeath += HandleEnemyDeath;
            EnemyController.OnEnemyReachedEnd += HandleEnemyReachedEnd;
            TowerPlacementController.OnTowerPlaced += HandleTowerPlaced;
            ButtonController.OnTowerSellClicked += HandleTowerSellClicked;
        }

        protected override void Unsubscribe()
        {
            EnemyController.OnEnemyDeath -= HandleEnemyDeath;
            EnemyController.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
            TowerPlacementController.OnTowerPlaced -= HandleTowerPlaced;
            ButtonController.OnTowerSellClicked -= HandleTowerSellClicked;
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
    }
}