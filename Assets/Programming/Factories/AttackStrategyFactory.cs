using System.Collections.Generic;
using Settings.Programming.Enums;
using Settings.Programming.Player;
using Settings.Programming.Player.Strategy;

namespace Settings.Programming.Factories
{
    public sealed class AttackStrategyFactory
    {
        private readonly Dictionary<AttackType, IAttackStrategy> _strategies = new();
        
        public AttackStrategyFactory(BaseObjectController objectController)
        {
            _strategies[AttackType.Hitscan] = new HitScanStrategy(objectController);
            _strategies[AttackType.Projectile] = new ProjectileStrategy(objectController);
            _strategies[AttackType.Interactable] = new InteractableStrategy(objectController);
        }
        
        public IAttackStrategy GetStrategy(AttackType type)
        {
            return _strategies[type];
        }
    }
}