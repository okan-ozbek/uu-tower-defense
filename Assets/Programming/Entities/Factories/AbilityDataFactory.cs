using Programming.Configs;
using Programming.Data;

namespace Programming.Entities.Factories
{
    public static class AbilityDataFactory
    {
        public static AbstractAbilityData Create(AbstractAbilityConfig config)
        {
            return config switch
            {
                HitscanAbilityConfig hitscanConfig => new HitscanAbilityData(hitscanConfig),
                ProjectileAbilityConfig projectileConfig => new ProjectileAbilityData(projectileConfig),
                _ => null
            };
        }
    }
}