using Settings.Programming.Enemies;
using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Player.Strategy
{
    public class HitScanStrategy : IAttackStrategy
    {
        private readonly ObjectStats _stats;
        
        public HitScanStrategy(ObjectStats stats)
        {
            _stats = stats;
        }
        
        public void Shoot(GameObject target)
        {
            if (target && _stats.HasReloaded)
            {
                Debug.Log($"Shot enemy hitscan");
                target.GetComponent<EnemyController>().Stats.TakeDamage(_stats.Attack.GetCurrentValue(), OperatorType.Subtraction);
                _stats.ResetReloadTime();
            }
        }
    }
}