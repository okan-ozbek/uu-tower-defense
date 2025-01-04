using Controllers.UI;
using Models;
using UnityEngine;

namespace Controllers.Towers
{
    public class TowerUpgradeController : Controller<Tower>
    {
        private int _rangeUpgradeCount = 0;
        private int _speedUpgradeCount = 0;
        private int _upgradeCount = 0;
        
        protected override void Subscribe()
        {
            
            
            GameButtonController.OnTowerIncreaseRangeClicked += HandleTowerIncreaseRange;
            GameButtonController.OnTowerIncreaseSpeedClicked += HandleTowerIncreaseSpeed;
            GameButtonController.OnTowerUpgradeClicked += HandleTowerUpgrade;     
        }
        
        protected override void Unsubscribe()
        {
            GameButtonController.OnTowerIncreaseRangeClicked -= HandleTowerIncreaseRange;
            GameButtonController.OnTowerIncreaseSpeedClicked -= HandleTowerIncreaseSpeed;
            GameButtonController.OnTowerUpgradeClicked -= HandleTowerUpgrade;
        }
        
        private void HandleTowerIncreaseRange(TowerController controller)
        {
            if (Model.Guid != controller.Model.Guid)
            {
                return;
            }
            
            if (_rangeUpgradeCount < controller.Model.MaxRangeUpgrades && controller.Model.isRangeMaxed == false)
            {
                controller.HandleTowerIncreaseRange();
                _rangeUpgradeCount++;
                
                controller.Model.isRangeMaxed = _rangeUpgradeCount == controller.Model.MaxRangeUpgrades;
            }
        }
        
        private void HandleTowerIncreaseSpeed(TowerController controller)
        {
            if (Model.Guid != controller.Model.Guid)
            {
                return;
            }
            
            if (_speedUpgradeCount < controller.Model.MaxSpeedUpgrades && controller.Model.isSpeedMaxed == false)
            {
                controller.HandleTowerIncreaseSpeed();
                _speedUpgradeCount++;
                
                controller.Model.isSpeedMaxed = _speedUpgradeCount == controller.Model.MaxSpeedUpgrades;
            }
        }
        
        private void HandleTowerUpgrade(TowerController controller)
        {
            if (Model.Guid != controller.Model.Guid)
            {
                return;
            }
            
            if (_upgradeCount < controller.Model.MaxUpgradeUpgrades && controller.Model.isUpgradeMaxed == false)
            {
                _upgradeCount++;
             
                controller.Model.isUpgradeMaxed = _upgradeCount == controller.Model.MaxUpgradeUpgrades;
            }
        }
    }
}