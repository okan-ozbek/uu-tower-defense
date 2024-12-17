using System.Collections.Generic;
using Programming.Controllers;
using Programming.Object.Enums;
using Programming.Towers.Strategies;

namespace Programming.Towers.Factories
{
    public sealed class AbilityStrategyFactory
    {
        private readonly Dictionary<AbilityType, IAbilityStrategy> _strategies = new();
        
        public AbilityStrategyFactory(TowerController towerController)
        {
            _strategies[AbilityType.Hitscan] = new HitScanStrategy(towerController);
            _strategies[AbilityType.Projectile] = new ProjectileStrategy(towerController);
            //_strategies[AttackType.Magic] = new MagicStrategy(towerController);
        }
        
        public IAbilityStrategy GetStrategy(AbilityType abilityType)
        {
            return _strategies[abilityType];
        }
    }
}