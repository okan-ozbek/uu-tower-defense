using Programming.Controllers;
using Programming.Data;
using UnityEngine;

namespace Programming.Abilities.Strategies
{
    public class SingleTargetStrategy : AbstractAbilityStrategy
    {
        public SingleTargetStrategy(AbstractAbilityData data) : base(data) { }

        protected override void Handle(GameObject self)
        {
            GameObject target = self.GetComponent<TowerController>().GetClosestEnemy();

            if (target)
            {
                OnUseTarget(target, self);
            }
        }
    }
}