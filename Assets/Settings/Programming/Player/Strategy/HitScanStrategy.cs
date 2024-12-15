using Settings.Programming.Enemies;
using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Player.Strategy
{
    public class HitScanStrategy : IAttackStrategy
    {
        private readonly BaseObjectController _objectController;
        
        public HitScanStrategy(BaseObjectController objectController)
        {
            _objectController = objectController;
        }
        
        public void Use(GameObject target)
        {
            if (target && _objectController.Stats.HasReloaded)
            {
                Debug.Log($"Shot enemy hitscan");
                target.GetComponent<EnemyController>().TakeDamage(_objectController.Stats.Attack.GetCurrentValue(), OperatorType.Subtraction);
                _objectController.Stats.ResetReloadTime();
            }
        }
    }
}