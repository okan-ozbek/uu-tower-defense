using Programming.Controllers;
using Programming.Stats;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public class HitScanStrategy : BaseAttackStrategy
    {
        private readonly TowerController _controller;
        
        public HitScanStrategy(TowerController controller)
        {
            _controller = controller;
        }
        
        public override void Use(GameObject target, AttackStat attackStat)
        {
            if (Validated(target, attackStat)) 
            {
                target.GetComponent<EnemyController>().model.Health.Value -= _controller.model.Damage.Value;
                attackStat.ResetCooldownTime();
                
                Debug.DrawLine(_controller.transform.position, target.transform.position, Color.blue, 3f);
            }
        }
    }
}