using Controllers.UI;
using Models;
using UnityEngine;

namespace Controllers.Towers
{
    [RequireComponent(
        requiredComponent:  typeof(TowerDetectionController),
        requiredComponent2: typeof(TowerAttackController),
        requiredComponent3: typeof(TowerUpgradeController)
    )]
    public class TowerController : Controller<Tower>
    {
        protected override void Subscribe()
        {
            TowerDetectionController.OnTargetChanged += HandleTargetChanged;
            ButtonController.OnTowerSellClicked += HandleTowerSellClicked;
        }

        protected override void Unsubscribe()
        {
            TowerDetectionController.OnTargetChanged -= HandleTargetChanged;
            ButtonController.OnTowerSellClicked -= HandleTowerSellClicked;
        }

        private void HandleTargetChanged(GameObject target)
        {
            Vector3 targetPosition = (target) 
                ? (Vector2)target.transform.position
                : PathController.GetClosestWaypoint(transform.position);
            
            Vector2 direction = targetPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }

        private void HandleTowerSellClicked(TowerController controller)
        {
            if (Model.Guid == controller.Model.Guid)
            {
                Destroy(gameObject);
            }
        }
        
        public void HandleTowerUpgrade()
        {
            // Empty for now
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Model.Range.Value);
        }
    }
}