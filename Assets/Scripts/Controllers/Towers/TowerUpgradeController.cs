using Controllers.UI;
using Models;
using UnityEngine;

namespace Controllers.Towers
{
    public class TowerUpgradeController : Controller<Tower>
    {
        protected override void Subscribe()
        {
            ButtonController.OnTowerUpgradeClicked += HandleTowerUpgrade;     
        }
        
        protected override void Unsubscribe()
        {
            ButtonController.OnTowerUpgradeClicked -= HandleTowerUpgrade;
        }
        
        private void HandleTowerUpgrade(TowerController controller)
        {
            controller.HandleTowerUpgrade();
        }
    }
}