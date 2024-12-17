using Programming.Controllers;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public class ProjectileStrategy : IAttackStrategy
    {
        private readonly TowerController _towerController;
        
        public ProjectileStrategy(TowerController towerController)
        {
            _towerController = towerController;
        }

        public void Use(GameObject target)
        {
            // Pew pew
        }
    }
}