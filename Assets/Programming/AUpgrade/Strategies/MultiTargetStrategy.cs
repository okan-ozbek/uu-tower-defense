using System.Collections;
using UnityEngine;

public class SingleTargetStrategy : AbstractAbilityStrategy
{
    public class SingleTargetStrategy(AbstractAbilityData data) : base(data) { }

    protected override void Handle(GameObject self)
    {
        List<GameObject> targets = self.GetComponent<EnemyController>().GetEnemies()

        foreach (GameObject target in targets)
        {
            OnUseTarget(enemy, self);
        }
    }
}