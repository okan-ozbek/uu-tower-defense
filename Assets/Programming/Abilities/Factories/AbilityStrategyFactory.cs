using Programming.Abilities.Strategies;
using Programming.Data;
using Programming.Entities.Enums;

namespace Programming.Abilities.Factories
{
    public static class AbilityStrategyFactory
    {
        public static IAbilityStrategy Create(AbstractAbilityData data)
        {
            if (data is ProjectileAbilityData { TargetType: TargetType.NoTarget } projectileData)
            {
                return new NoTargetStrategy(projectileData);
            }

            return data.TargetType switch
            {
                TargetType.SingleTarget => new SingleTargetStrategy(data),
                TargetType.MultiTarget => new MultiTargetStrategy(data),
                _ => null
            };
        }
    }
}