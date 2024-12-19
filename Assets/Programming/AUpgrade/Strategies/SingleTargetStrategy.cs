using System.Collections;
using UnityEngine;

public class SingleTargetStrategy : AbstractAbilityStrategy
{
    public class SingleTargetStrategy(AbstractAbilityData data) : base(data) { }

    protected override void Handle(GameObject self)
    {
        GameObject target = self.GetComponent<EnemyController>().GetClosestEnemy()

        OnUseTarget(target, self);
    }
}