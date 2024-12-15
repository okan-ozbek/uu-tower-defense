using System.Collections.Generic;
using Settings.Programming.Enums;
using Settings.Programming.Player;
using Settings.Programming.Player.Strategy;

namespace Settings.Programming.Factories
{
    public class AttackStrategyFactory
    {
        private Dictionary<AttackType, IAttackStrategy> _strategies = new();

        public AttackStrategyFactory(ObjectStats stats)
        {
            _strategies[AttackType.Hitscan] = new HitScanStrategy(stats);
            _strategies[AttackType.Projectile] = new ProjectileStrategy(stats);
        }

        public IAttackStrategy GetAttack(AttackType type)
        {
            return _strategies[type];
        }
    }
}