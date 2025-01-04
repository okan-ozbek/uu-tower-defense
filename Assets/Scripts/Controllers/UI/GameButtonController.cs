using System;
using System.Collections.Generic;
using Controllers.Towers;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class GameButtonController : MonoBehaviour
    {
        [Header("Tower")] 
        [SerializeField] private Button towerIncreaseRangeButton;
        [SerializeField] private Button towerIncreaseSpeedButton;
        [SerializeField] private Button towerUpgradeButton;
        [SerializeField] private Button towerReturnButton;
        [SerializeField] private Button towerSellButton;
        
        [Header("Game specific")]
        [SerializeField] private Button startWaveButton;
        
        [Header("Quit game")] 
        [SerializeField] private Button exitGameButton;
        [SerializeField] private Button yesQuitGameButton;
        [SerializeField] private Button noQuitGameButton;
        
        [Header("Settings")]
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button applySettingsButton;
        [SerializeField] private Button cancelSettingsButton;

        #region Events
        public static event Action<TowerController> OnTowerIncreaseRangeClicked;
        public static event Action<TowerController> OnTowerIncreaseSpeedClicked;
        public static event Action<TowerController> OnTowerUpgradeClicked;
        public static event Action<TowerController> OnTowerSellClicked;
        public static event Action OnReturnFromStatsClicked;
        public static event Action OnStartWaveClicked;
        
        public static event Action OnExitGameClicked;
        public static event Action OnYesQuitGameClicked;
        public static event Action OnNoQuitGameClicked;
        
        public static event Action OnSettingsClicked;
        public static event Action OnApplySettingsClicked;
        public static event Action OnCancelSettingsClicked;
        #endregion
        
        private TowerController _selectedTower;
        
        private void OnEnable()
        {
            MouseSelectionController.OnTowerSelected += HandleTowerSelected;
            
            towerIncreaseRangeButton.onClick.AddListener(() => OnTowerIncreaseRangeClicked?.Invoke(_selectedTower));
            towerIncreaseSpeedButton.onClick.AddListener(() => OnTowerIncreaseSpeedClicked?.Invoke(_selectedTower));
            towerUpgradeButton.onClick.AddListener(() => OnTowerUpgradeClicked?.Invoke(_selectedTower));
            towerReturnButton.onClick.AddListener(() => OnReturnFromStatsClicked?.Invoke());
            towerSellButton.onClick.AddListener(() => OnTowerSellClicked?.Invoke(_selectedTower));
            
            startWaveButton.onClick.AddListener(() => OnStartWaveClicked?.Invoke());
            
            exitGameButton.onClick.AddListener(() => OnExitGameClicked?.Invoke());
            yesQuitGameButton.onClick.AddListener(() => OnYesQuitGameClicked?.Invoke());
            noQuitGameButton.onClick.AddListener(() => OnNoQuitGameClicked?.Invoke());
            
            settingsButton.onClick.AddListener(() => OnSettingsClicked?.Invoke());
            applySettingsButton.onClick.AddListener(() => OnApplySettingsClicked?.Invoke());
            cancelSettingsButton.onClick.AddListener(() => OnCancelSettingsClicked?.Invoke());
        }
        
        private void OnDisable()
        {
            MouseSelectionController.OnTowerSelected -= HandleTowerSelected;
            
            towerIncreaseRangeButton.onClick.RemoveAllListeners();
            towerIncreaseSpeedButton.onClick.RemoveAllListeners();
            towerUpgradeButton.onClick.RemoveAllListeners();
            towerReturnButton.onClick.RemoveAllListeners();
            towerSellButton.onClick.RemoveAllListeners();
            
            startWaveButton.onClick.RemoveAllListeners();
            
            settingsButton.onClick.RemoveAllListeners();
            applySettingsButton.onClick.RemoveAllListeners();
            cancelSettingsButton.onClick.RemoveAllListeners();
        }

        private void HandleTowerSelected(TowerController controller)
        {
            _selectedTower = controller;
        }
    }
}