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
            List<GameObject> targets = self.GetComponent<TowerController>().GetEnemies();

            foreach (GameObject target in targets)
            {
                OnUseTarget(target, self);
            }
        }
    }
}