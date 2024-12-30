using Configs;
using Enums;
using Models;
using UnityEngine;

namespace DTOs
{
    public class TowerAttackDTO
    {
        public readonly AttackPatternType AttackPatternType;
        public readonly GameObject ProjectilePrefab;
        public readonly GameObject Tower;
        public readonly float Cooldown;
        public readonly int Count;
        public readonly float BurstCooldown;
        
        public TowerAttackDTO(Tower model, AttackConfig config, GameObject tower)
        {
            AttackPatternType = config.attackPatternType;
            ProjectilePrefab = config.projectilePrefab;
            Tower = tower;
            Cooldown = model.Cooldown.Value;
            Count = config.count;
            BurstCooldown = config.burstCooldown;
        }
    }
}