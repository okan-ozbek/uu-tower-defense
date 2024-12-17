using Programming.Controllers;
using Programming.Stats;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public class MagicStrategy : BaseAbilityStrategy
    {
        private readonly TowerController _controller;

        public MagicStrategy(TowerController controller)
        {
            _controller = controller;
        }

        public override void Use(GameObject target, AbilityStat abilityStat)
        {
            // throw new System.NotImplementedException();
        }
    }
}