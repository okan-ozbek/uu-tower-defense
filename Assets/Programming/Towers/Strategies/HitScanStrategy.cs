using Programming.Controllers;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public class HitScanStrategy : IAttackStrategy
    {
        private readonly TowerController _controller;
        
        public HitScanStrategy(TowerController controller)
        {
            _controller = controller;
        }
        
        public void Use(GameObject target)
        {
            if (target && _controller.model.HasReloaded())
            {
                target.GetComponent<EnemyController>().model.Health.Value -= _controller.model.Damage.Value;
                _controller.model.ResetReloadTime();
                
                Debug.DrawLine(_controller.transform.position, target.transform.position, Color.blue, 1f);
            }
        }
    }
}