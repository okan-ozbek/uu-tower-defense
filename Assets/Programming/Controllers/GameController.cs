using System;
using System.Collections.Generic;
using Programming.Entities;
using Programming.Models;
using Programming.Views;
using UnityEngine;

namespace Programming.Controllers
{
    [RequireComponent(
        requiredComponent:  typeof(WaveSystem), 
        requiredComponent2: typeof(GameModel),
        requiredComponent3: typeof(GameView)
    )]
    public class GameController : Controller<GameModel>
    {
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