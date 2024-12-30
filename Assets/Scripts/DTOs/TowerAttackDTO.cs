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
        
        public TowerAttackDTO(Tower model, GameObject projectilePrefab, GameObject tower)
        {
            AttackPatternType = model.AttackPatternType;
            ProjectilePrefab = projectilePrefab;
            Tower = tower;
            Cooldown = model.Cooldown.Value;
            Count = model.Count;
            BurstCooldown = model.BurstCooldown;
        }
    }
}