using Programming.Controllers;
using Programming.Stats;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public class ProjectileStrategy : BaseAttackStrategy
    {
        private readonly TowerController _towerController;
        
        public ProjectileStrategy(TowerController towerController)
        {
            _towerController = towerController;
        }

        public override void Use(GameObject target, AttackStat attackStat)
        {
            // throw new System.NotImplementedException();
        }
    }
}