using System.Collections.Generic;
using Programming.Controllers;
using Programming.Object.Enums;
using Programming.Towers.Strategies;

namespace Programming.Towers.Factories
{
    public sealed class AttackStrategyFactory
    {
        private readonly Dictionary<AttackType, IAttackStrategy> _strategies = new();
        
        public AttackStrategyFactory(TowerController towerController)
        {
            _strategies[AttackType.Hitscan] = new HitScanStrategy(towerController);
            _strategies[AttackType.Projectile] = new ProjectileStrategy(towerController);
            //_strategies[AttackType.Magic] = new MagicStrategy(towerController);
        }
        
        public IAttackStrategy GetStrategy(AttackType attackType)
        {
            return _strategies[attackType];
        }
    }
}