using System.Collections;
using UnityEngine;

public abstract class AbstractAbilityStrategy : IAbilityStrategy
{
    protected AbstractAbilityData Data;

    public AbstractAbilityStrategy(AbstractAbilityData data)
    {
        Data = data;
    }

    public void Use(GameObject self)
    {
        if (Data.OnCooldown())
        {
            return;
        }

        Handle(self);
    }

    protected abstract void Handle(GameObject self);

    protected void OnUseTarget(GameObject target, GameObject self)
    {
        if (Data is HitscanAbilityData hitscanData)
        {
            target.GetComponent<EnemyModel>().Health.Value -= hitscanData.Damage;
            hitscanData.ResetCooldown();

            return;
        }

        if (Data is ProjectileAbilityData projectileData)
        {
            GameObject instance = GameObject.Instantiate(projectileData.ProjectilePrefab, self.transform.position, Quaternion.identity);
            projectileData.ResetCooldown();

            return;
        }
    }
}