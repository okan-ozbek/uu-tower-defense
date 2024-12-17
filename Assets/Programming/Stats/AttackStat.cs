using Programming.Configs;
using Programming.Object.Enums;
using UnityEngine;

namespace Programming.Stats
{
    public class AttackStat
    {
        private readonly TowerAttackConfig _attackConfig;
        private readonly Stat<float> _cooldown;
        private float _timePassed;

        public Stat<float> Value;

        public AttackType AttackType => _attackConfig.attackType;

        public AttackStat(TowerAttackConfig attackConfig)
        {
            _attackConfig = attackConfig;

            Value = new Stat<float>(attackConfig.value);
            _cooldown = new Stat<float>(attackConfig.cooldown);
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