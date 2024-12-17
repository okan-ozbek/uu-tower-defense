using Programming.Configs;
using Programming.Entities.Enums;
using UnityEngine;

namespace Programming.Entities.Stats
{
    public class AbilityStat
    {
        private readonly TowerAbilityConfig _abilityConfig;
        private float _timePassed;

        public GenericStat<float> Value;
        private readonly GenericStat<float> _cooldown;

        public AbilityType AbilityType => _abilityConfig.abilityType;

        public AbilityStat(TowerAbilityConfig abilityConfig)
        {
            _abilityConfig = abilityConfig;

            Value = new GenericStat<float>(abilityConfig.value);
            _cooldown = new GenericStat<float>(abilityConfig.cooldown);
        }

        public bool OnCooldown()
        {
            return (_timePassed < _cooldown.Value);
        }
        
        public void UpdateCooldownTime()
        {
            _timePassed += Time.deltaTime;
        }

        public void ResetCooldownTime()
        {
            _timePassed = 0.0f;
        }
    }
}