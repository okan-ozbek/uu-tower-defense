using System;
using Controllers;
using Controllers.Towers;
using Controllers.UI;
using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class StatsPanel : View
    {
        [SerializeField] private TMP_Text damageText;
        [SerializeField] private TMP_Text speedText;
        
        private Guid _selectedTowerGuid;
        
        protected override void Subscribe()
        {
            MouseSelectionController.OnTowerSelected += HandleTowerSelected;
        }
    
        protected override void Unsubscribe()
        {
            MouseSelectionController.OnTowerSelected -= HandleTowerSelected;
        }

        private void HandleTowerSelected(TowerController controller)
        {
            if (_selectedTowerGuid != Guid.Empty && _selectedTowerGuid != controller.Model.Guid)
            {
                HandleTowerDeselected(controller);
            }
            
            _selectedTowerGuid = controller.Model.Guid;
        }
        
        private void HandleTowerDeselected(TowerController controller)
        {
            _selectedTowerGuid = Guid.Empty;
        }
    }
}