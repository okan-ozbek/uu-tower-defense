using Programming.Controllers;
using Programming.Data;
using UnityEngine;

namespace Programming.Entities.Strategies
{
    public class SingleTargetStrategy : AbstractAbilityStrategy
    {
        public SingleTargetStrategy(AbstractAbilityData data) : base(data) { }

        protected override void Handle(GameObject self)
        {
            GameObject target = self.GetComponent<TowerController>().GetClosestEnemy();

            OnUseTarget(target, self);
        }
    }
}