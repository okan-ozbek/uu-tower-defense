using UnityEngine;

namespace Settings.Programming.Player.Strategy
{
    public class ProjectileStrategy : IAttackStrategy
    {
        private readonly BaseObjectController _objectController;
        
        public ProjectileStrategy(BaseObjectController objectController)
        {
            _objectController = objectController;
        }

        public void Use(GameObject target)
        {
            // Pew pew
        }
    }
}