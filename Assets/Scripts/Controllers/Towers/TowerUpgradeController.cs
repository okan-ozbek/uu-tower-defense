using Controllers.UI;
using Models;
using UnityEngine;

namespace Controllers.Towers
{
    public class TowerUpgradeController : Controller<Tower>
    {
        protected override void Subscribe()
        {
            ButtonController.OnTowerIncreaseRangeClicked += HandleTowerIncreaseRange;
            ButtonController.OnTowerIncreaseSpeedClicked += HandleTowerIncreaseSpeed;
            ButtonController.OnTowerUpgradeClicked += HandleTowerUpgrade;     
        }
        
        protected override void Unsubscribe()
        {
            ButtonController.OnTowerIncreaseRangeClicked -= HandleTowerIncreaseRange;
            ButtonController.OnTowerIncreaseSpeedClicked -= HandleTowerIncreaseSpeed;
            ButtonController.OnTowerUpgradeClicked -= HandleTowerUpgrade;
        }
        
        private void HandleTowerIncreaseRange(TowerController controller)
        {
            controller.HandleTowerIncreaseRange();
        }
        
        private void HandleTowerIncreaseSpeed(TowerController controller)
        {
            controller.HandleTowerIncreaseSpeed();
        }
        
        private void HandleTowerUpgrade(TowerController controller)
        {
            controller.HandleTowerUpgrade();
        }
    }
}