using Programming.Data;
using Programming.Models;
using UnityEngine;

namespace Programming.Abilities.Strategies
{
    public abstract class AbstractAbilityStrategy : IAbilityStrategy
    {
        protected AbstractAbilityData Data;

        protected AbstractAbilityStrategy(AbstractAbilityData data)
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
            switch (Data)
            {
                case HitscanAbilityData hitscanData:
                    target.GetComponent<EnemyModel>().Health.Value -= hitscanData.Damage;
                    hitscanData.ResetCooldown();
                    return;
                case ProjectileAbilityData projectileData:
                {
                    Object instance = Object.Instantiate(projectileData.ProjectilePrefab, self.transform.position, self.transform.rotation);
                    projectileData.ResetCooldown();
                    return;
                }
            }
        }
    }
}
