using System;
using Configs;
using UnityEngine;
using Utility;

namespace Models
{
    public class Enemy : Model
    {
        [SerializeField] private EnemyConfig config;
        
        public Guid Guid { get; private set; }
        
        public Stat<float> Health;
        public Stat<float> Damage;
        public Stat<float> Speed;

        public float Reward => config.reward;
        public float Cost => config.cost;

        protected override void Start()
        {
            Guid = Guid.NewGuid();
            
            Health = new Stat<float>(config.health);
            Damage = new Stat<float>(config.damage);
            Speed = new Stat<float>(config.speed);
        }
    }
}