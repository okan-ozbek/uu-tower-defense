using Programming.Data;
using UnityEngine;

namespace Programming.Entities.Strategies
{
    public class NoTargetStrategy : AbstractAbilityStrategy
    {
        public NoTargetStrategy(ProjectileAbilityData data) : base(data) { }

        protected override void Handle(GameObject self)
        {
            if (Data is ProjectileAbilityData data)
            {
                for (int index = 0; index < data.Count; index++) {
                    float angle = (360f / data.Count) * index;

                    Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                    Object instance = Object.Instantiate(data.ProjectilePrefab, self.transform.position, Quaternion.Euler(0, angle, 0));
                }    
                
                data.ResetCooldown();
            }
        }
    }
}