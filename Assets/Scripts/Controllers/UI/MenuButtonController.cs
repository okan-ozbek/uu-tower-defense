using System;
using System.Collections.Generic;
using Controllers.Towers;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class MenuButtonController : MonoBehaviour
    {
        [Header("Game specific")]
        [SerializeField] private Button startGameButton;
        
        [Header("Quit game")] 
        [SerializeField] private Button exitGameButton;
        [SerializeField] private Button yesQuitGameButton;
        [SerializeField] private Button noQuitGameButton;
        
        [Header("Settings")]
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button applySettingsButton;
        [SerializeField] private Button cancelSettingsButton;

        #region Events
        public static event Action OnStartGameClicked;
        
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
            startGameButton.onClick.AddListener(() => OnStartGameClicked?.Invoke());
            
            exitGameButton.onClick.AddListener(() => OnExitGameClicked?.Invoke());
            yesQuitGameButton.onClick.AddListener(() => OnYesQuitGameClicked?.Invoke());
            noQuitGameButton.onClick.AddListener(() => OnNoQuitGameClicked?.Invoke());
            
            settingsButton.onClick.AddListener(() => OnSettingsClicked?.Invoke());
            applySettingsButton.onClick.AddListener(() => OnApplySettingsClicked?.Invoke());
            cancelSettingsButton.onClick.AddListener(() => OnCancelSettingsClicked?.Invoke());
        }
        
        private void OnDisable()
        {
            startGameButton.onClick.RemoveAllListeners();
            
            exitGameButton.onClick.RemoveAllListeners();
            yesQuitGameButton.onClick.RemoveAllListeners();
            noQuitGameButton.onClick.RemoveAllListeners();
            
            settingsButton.onClick.RemoveAllListeners();
            applySettingsButton.onClick.RemoveAllListeners();
            cancelSettingsButton.onClick.RemoveAllListeners();
        }
    }
}