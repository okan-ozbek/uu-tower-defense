using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Controllers.Towers;
using Controllers.UI;
using DTOs;
using Enums;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Views
{
    public class UpgradePanel : View
    {
        private Guid _selectedTowerGuid;
        private TowerController _selectedTower;

        [SerializeField] private List<UpgradeButtonDTO> buttons;
        [SerializeField] private Button sellButton;
        
        protected override void Subscribe()
        {
            GameController.OnTowerSelectedUpdateMoney += HandleMoneyChanged;
            Game.OnMoneyChanged += HandleMoneyChanged;
            MouseSelectionController.OnTowerSelected += HandleTowerSelected;
        }
    
        protected override void Unsubscribe()
        {
            GameController.OnTowerSelectedUpdateMoney -= HandleMoneyChanged;
            Game.OnMoneyChanged -= HandleMoneyChanged;
            MouseSelectionController.OnTowerSelected -= HandleTowerSelected;
        }

        private void Update()
        {
            if (_selectedTower)
            {
                CheckInteractableButtons();
            }
        }

        private void HandleTowerSelected(TowerController controller)
        {
            if (_selectedTowerGuid != Guid.Empty && _selectedTowerGuid != controller.Model.Guid)
            {
                HandleTowerDeselected(controller);
            }
            
            _selectedTowerGuid = controller.Model.Guid;
            _selectedTower = controller;
            
            sellButton.GetComponentInChildren<TMP_Text>().text = $"Sell (${controller.Model.Sell})";
        }
        
        private void HandleMoneyChanged(float money)
        {
            foreach (UpgradeButtonDTO upgradeButton in buttons)
            {
                upgradeButton.Button.GetComponent<Button>().interactable = (money >= upgradeButton.cost);
            }
        }
        
        private void HandleTowerDeselected(TowerController controller)
        {
            _selectedTowerGuid = Guid.Empty;
        }

        private void CheckInteractableButtons()
        {
            foreach (var upgradeButton in buttons.Where(upgradeButton => upgradeButton.Button.interactable))
            {
                upgradeButton.Button.GetComponent<Button>().interactable = upgradeButton.upgradeButtonType switch
                {
                    UpgradeButtonType.IncreaseRange => _selectedTower.Model.isRangeMaxed == false,
                    UpgradeButtonType.IncreaseSpeed => _selectedTower.Model.isSpeedMaxed == false,
                    UpgradeButtonType.Upgrade => _selectedTower.Model.isUpgradeMaxed == false,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }
}