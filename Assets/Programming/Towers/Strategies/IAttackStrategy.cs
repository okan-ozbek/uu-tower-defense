using Programming.Stats;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public interface IAttackStrategy
    {
        public void Use(GameObject target, AttackStat attackStat);
        public bool Validated(GameObject target, AttackStat attackStat);
    }
}