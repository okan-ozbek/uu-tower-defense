using Programming.Controllers;
using Programming.Entities.Stats;
using UnityEngine;

namespace Programming.Entities.Strategies
{
    public class ProjectileStrategy : BaseAbilityStrategy
    {
        private readonly TowerController _towerController;
        
        public ProjectileStrategy(TowerController towerController)
        {
            _towerController = towerController;
        }

        public override void Use(GameObject target, AbilityStat abilityStat)
        {
            // throw new System.NotImplementedException();
        }
    }
}