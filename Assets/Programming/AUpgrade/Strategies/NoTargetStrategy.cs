using System.Collections;
using UnityEngine;

public class SingleTargetStrategy : AbstractAbilityStrategy
{
    public class SingleTargetStrategy(AbstractAbilityData data) : base(data) { }

    protected override void Handle(GameObject self)
    {
        for (int index = 0; index < count; index++) {
                float angle = (360f / count) * index;

                Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                GameObject instance = GameObject.Instantiate(projectilePrefab, self.transform.position, Quaternion.Euler(0, angle, 0));
            }
            
            ResetCooldown();
        }
    }
}