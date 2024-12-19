using Programming.Configs;
using Programming.Entities.Enums;

namespace Programming.Data
{
    public abstract class AbstractAbilityData
    {
        private AbstractAbilityConfig _config;

        public float Range;
        public float Damage;
        public float Cooldown;
        public float Count;
        public TargetType TargetType;

        private float _timeSinceLastUse;

        public AbstractAbilityData(AbstractAbilityConfig config)
        {
            _config = config;

            Range = config.range;
            Damage = config.damage;
            Cooldown = config.cooldown;
            Count = config.count;
            TargetType = config.targetType;
        }

        public bool OnCooldown()
        {
            return _timeSinceLastUse < Cooldown;
        }

        public void ResetCooldown()
        {
            _timeSinceLastUse = 0.0f;
        }

        public void Update(float deltaTime)
        {
            _timeSinceLastUse += deltaTime;
        }
    }
}