using System;
using System.Collections.Generic;
using Controllers;
using Controllers.Towers;
using Controllers.UI;
using DTOs;
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

        private void HandleTowerSelected(TowerController controller)
        {
            if (_selectedTowerGuid != Guid.Empty && _selectedTowerGuid != controller.Model.Guid)
            {
                HandleTowerDeselected(controller);
            }
            
            _selectedTowerGuid = controller.Model.Guid;
            
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
    }
}