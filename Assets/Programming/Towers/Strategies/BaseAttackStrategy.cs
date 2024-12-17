using Programming.Stats;
using UnityEngine;

namespace Programming.Towers.Strategies
{
    public abstract class BaseAttackStrategy : IAttackStrategy
    {
        public abstract void Use(GameObject target, AttackStat attackStat);

        public bool Validated(GameObject target, AttackStat attackStat)
        {
            return (target && attackStat.OnCooldown() == false);
        }
    }
}