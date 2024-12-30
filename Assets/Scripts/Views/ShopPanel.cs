using System.Collections.Generic;
using Controllers.Enemies;
using Controllers.UI;
using DTOs;
using Models;
using UnityEngine;

namespace Views
{
    public class ShopPanel : View
    {
        private readonly List<ShopButtonDTO> _shopButtons = new();
        private bool _waveInProgress;
        
        protected override void Subscribe()
        {
            Game.OnMoneyChanged += HandleMoneyChanged;
            ShopController.OnButtonCreated += HandleButtonCreated;
            WaveSystem.OnWaveStarted += HandleWaveStarted;
            WaveSystem.OnWaveFinished += HandleWaveFinished;
        }

        protected override void Unsubscribe()
        {
            Game.OnMoneyChanged -= HandleMoneyChanged;
            ShopController.OnButtonCreated -= HandleButtonCreated;
            WaveSystem.OnWaveStarted -= HandleWaveStarted;
            WaveSystem.OnWaveFinished -= HandleWaveFinished;
        }
        
        private void HandleMoneyChanged(float money)
        {
            foreach (ShopButtonDTO shopButton in _shopButtons)
            {
                shopButton.Button.interactable = (money >= shopButton.Cost && _waveInProgress == false);
            }
        }
        
        private void HandleButtonCreated(GameObject button, Tower tower)
        {
            _shopButtons.Add(new ShopButtonDTO(tower.Cost, button));
        }

        private void HandleWaveStarted()
        {
            foreach (ShopButtonDTO shopButton in _shopButtons)
            {
                _waveInProgress = true;
                shopButton.Button.interactable = false;
            }
        }

        private void HandleWaveFinished()
        {
            foreach (ShopButtonDTO shopButton in _shopButtons)
            {
                _waveInProgress = false;
                shopButton.Button.interactable = true;
            }
        }
    }
}