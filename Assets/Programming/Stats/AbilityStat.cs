using Programming.Configs;
using Programming.Object.Enums;
using UnityEngine;

namespace Programming.Stats
{
    public class AbilityStat
    {
        private readonly TowerAbilityConfig _abilityConfig;
        private readonly Stat<float> _cooldown;
        private float _timePassed;

        public Stat<float> Value;

        public AbilityType AbilityType => _abilityConfig.abilityType;

        public AbilityStat(TowerAbilityConfig abilityConfig)
        {
            _abilityConfig = abilityConfig;

            Value = new Stat<float>(abilityConfig.value);
            _cooldown = new Stat<float>(abilityConfig.cooldown);
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