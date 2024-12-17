using System;
using System.Collections.Generic;
using Programming.Enemies;
using Programming.Models;
using UnityEngine;

namespace Programming.Controllers
{
    [RequireComponent(
        requiredComponent:  typeof(WaveSystem), 
        requiredComponent2: typeof(GameModel)
    )]
    public class GameController : Controller<GameModel>
    {
        private WaveSystem _waveSystem;

        protected override void Awake()
        {
            base.Awake();
            
            _waveSystem = GetComponent<WaveSystem>();
        }
        
        public void HandleFinishedEvent(float value)
        {
            model.Health.Value -= value;
        }
        
        public void HandleDeathEvent(float value)
        {
            model.Money.Value += value;
        }

        public void PurchaseTower(float value)
        {
            model.Money.Value -= value;
        }
    }
}