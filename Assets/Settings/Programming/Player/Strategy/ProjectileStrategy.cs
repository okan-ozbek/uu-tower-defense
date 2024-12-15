using UnityEngine;

namespace Settings.Programming.Player.Strategy
{
    public class ProjectileStrategy : IAttackStrategy
    {
        private readonly ObjectStats _stats;
        
        public ProjectileStrategy(ObjectStats stats)
        {
            _stats = stats;
        }

        public void Shoot(GameObject target)
        {
            // Pew pew
        }
    }
}