using Programming.Controllers;
using Programming.Entities.Stats;
using UnityEngine;

namespace Programming.Entities.Strategies
{
    public class HitScanStrategy : BaseAbilityStrategy
    {
        private readonly TowerController _controller;
        
        public HitScanStrategy(TowerController controller)
        {
            _controller = controller;
        }
        
        public override void Use(GameObject target, AbilityStat abilityStat)
        {
            if (Validated(target, abilityStat)) 
            {
                target.GetComponent<EnemyController>().model.Health.Value -= _controller.model.Damage.Value;
                abilityStat.ResetCooldownTime();
                
                Debug.DrawLine(_controller.transform.position, target.transform.position, Color.blue, 3f);
            }
        }
    }
}