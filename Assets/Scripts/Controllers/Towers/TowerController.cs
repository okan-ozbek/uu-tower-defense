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
        [SerializeField] private GameObject radius;
        
        protected override void Subscribe()
        {
            TowerDetectionController.OnTargetChanged += HandleTargetChanged;
            ButtonController.OnTowerSellClicked += HandleTowerSellClicked;
            ButtonController.OnReturnFromStatsClicked += HandleTowerUnselected;
            MouseSelectionController.OnTowerSelected += HandleTowerSelected;
        }

        protected override void Unsubscribe()
        {
            TowerDetectionController.OnTargetChanged -= HandleTargetChanged;
            ButtonController.OnTowerSellClicked -= HandleTowerSellClicked;
            ButtonController.OnReturnFromStatsClicked -= HandleTowerUnselected;
            MouseSelectionController.OnTowerSelected -= HandleTowerSelected;
        }

        private void HandleTargetChanged(GameObject target)
        {
            if (Model.IsStationary)
            {
                return;
            }
            
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
        
        private void HandleTowerSelected(TowerController controller)
        {
            if (Model.Guid == controller.Model.Guid)
            {
                radius.SetActive(true);
                SetRadius();
            }

            if (Model.Guid != controller.Model.Guid)
            {
                radius.SetActive(false);
            }
        }

        private void HandleTowerUnselected()
        {
            radius.SetActive(false);
        }
        
        public void HandleTowerIncreaseRange()
        {
            Model.Range.Value += (Model.BaseRange * 0.3f);
            SetRadius();
        }
        
        public void HandleTowerIncreaseSpeed()
        {
            
            Model.Cooldown.Value -= (Model.Cooldown.Value * 0.2f);
        }

        private void SetRadius()
        {
            radius.transform.localScale = new Vector2(Model.Range.Value * 2.0f, Model.Range.Value * 2.0f);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Model.Range.Value);
        }
    }
}