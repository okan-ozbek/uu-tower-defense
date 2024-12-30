using System;
using Configs;
using Controllers.UI;
using UnityEngine;
using Utility;

namespace Models
{
    public class Game : Model
    {
        [SerializeField] private GameConfig config;
        
        public static event Action<float> OnHealthChanged;
        public static event Action<float> OnMoneyChanged;
        
        public Stat<float> Health;
        public Stat<float> Money;

        protected override void Start()
        {
            Health.OnValueChanged += (value) => OnHealthChanged?.Invoke(value);
            Money.OnValueChanged += (value) => OnMoneyChanged?.Invoke(value);
            
            Health.Value = config.health;
            Money.Value = config.money;
        }
    }
}