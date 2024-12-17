using Programming.Controllers;
using Programming.Stats;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public class MagicStrategy : BaseAttackStrategy
    {
        private readonly TowerController _controller;

        public MagicStrategy(TowerController controller)
        {
            _controller = controller;
        }

        public override void Use(GameObject target, AttackStat attackStat)
        {
            // throw new System.NotImplementedException();
        }
    }
}