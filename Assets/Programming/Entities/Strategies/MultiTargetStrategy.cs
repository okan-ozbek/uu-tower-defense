using System.Collections.Generic;
using Programming.Controllers;
using Programming.Data;
using UnityEngine;

namespace Programming.Entities.Strategies
{
    public class MultiTargetStrategy : AbstractAbilityStrategy
    {
        public MultiTargetStrategy(AbstractAbilityData data) : base(data) { }
    
        protected override void Handle(GameObject self)
        {
            var targets = self.GetComponent<TowerController>().GetEnemies();
            
            if (targets.Count > 0)
            {
                foreach (GameObject target in targets)
                {
                    OnUseTarget(target, self);
                }
            }
        }
    }
}