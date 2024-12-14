using Settings.Programming.Configs;
using Settings.Programming.Enums;
using Settings.Programming.Stats;

namespace Settings.Programming.Enemies
{
    public class EnemyStats
    {
        public readonly StatMediator Mediator;

        public readonly Stat<float> Health;
        public readonly Stat<float> Attack;
        public readonly Stat<float> Speed;

        public EnemyStats(EnemyStatConfig enemyStatConfig, StatMediator mediator)
        {
            Mediator = mediator;

            Health = new Stat<float>(Mediator, StatType.Health, enemyStatConfig.health);
            Attack = new Stat<float>(Mediator, StatType.Attack, enemyStatConfig.attack);
            Speed = new Stat<float>(Mediator, StatType.Speed, enemyStatConfig.speed, true);
        }

        public bool IsAlive()
        {
            return Health.GetCurrentValue() > 0;
        }
    }
}