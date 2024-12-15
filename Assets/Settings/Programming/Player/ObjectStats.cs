using Settings.Programming.Configs;
using Settings.Programming.Enums;
using Settings.Programming.Stats;

namespace Settings.Programming.Player
{
    public class ObjectStats 
    {
        public readonly StatMediator Mediator;

        public readonly Stat<float> Range;
        public readonly Stat<float> Attack;
        public readonly Stat<float> ReloadTime;
        public AttackType AttackType { get; }
        
        private readonly ObjectStatConfig _objectStatConfig;

        public ObjectStats(ObjectStatConfig objectStatConfig, StatMediator mediator)
        {
            _objectStatConfig = objectStatConfig;
            
            Mediator = mediator;
            
            Range = new Stat<float>(Mediator, StatType.Health, objectStatConfig.range);
            Attack = new Stat<float>(Mediator, StatType.Attack, objectStatConfig.attack);
            ReloadTime = new Stat<float>(Mediator, StatType.Speed, objectStatConfig.reloadTime, true);
            AttackType = objectStatConfig.attackType;
        }

        public bool HasReloaded => _objectStatConfig.HasReloaded();
        public void ResetReloadTime() => _objectStatConfig.ResetReloadTime();
    }
}