using Controllers.Towers;
using Singletons;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Views;

namespace Controllers.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject viewManager;
        
        private ShopPanel _shopPanel;
        private UpgradePanel _upgradePanel;
        private StartWaveContainer _startWaveContainer;
        private SettingsModal _settingsModal;
        private QuitGameModal _quitGameModal;

        private void Awake()
        {
            _shopPanel = viewManager.GetComponent<ShopPanel>();
            _upgradePanel = viewManager.GetComponent<UpgradePanel>();
            _startWaveContainer = viewManager.GetComponent<StartWaveContainer>();
            _settingsModal = viewManager.GetComponent<SettingsModal>();
            _quitGameModal = viewManager.GetComponent<QuitGameModal>();
        }
        
        private void OnEnable()
        {
            MouseSelectionController.OnTowerSelected += GetStatsPanel;
            ButtonController.OnTowerSellClicked += GetShopPanel;
            ButtonController.OnReturnFromStatsClicked += GetShopPanel;
            
            ButtonController.OnExitGameClicked += EnableExitGameModal;
            ButtonController.OnNoQuitGameClicked += DisableExitGameModal;
            
            ButtonController.OnSettingsClicked += EnableSettingsModal;
            ButtonController.OnApplySettingsClicked += DisableSettingsModal;
            ButtonController.OnCancelSettingsClicked += DisableSettingsModal;
        }
        
        private void OnDisable()
        {
            MouseSelectionController.OnTowerSelected -= GetStatsPanel;
            ButtonController.OnTowerSellClicked -= GetShopPanel;
            ButtonController.OnReturnFromStatsClicked -= GetShopPanel;
            
            ButtonController.OnExitGameClicked -= EnableExitGameModal;
            ButtonController.OnNoQuitGameClicked -= DisableExitGameModal;
            
            ButtonController.OnSettingsClicked -= EnableSettingsModal;
            ButtonController.OnApplySettingsClicked -= DisableSettingsModal;
            ButtonController.OnCancelSettingsClicked -= DisableSettingsModal;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GetShopPanel();
            }
        }

        private void EnableExitGameModal()
        {
            PauseSingleton.Pause();
            _quitGameModal.Activate();
        }
        
        private void DisableExitGameModal()
        {
            PauseSingleton.Unpause();
            _quitGameModal.Deactivate();
        }

        private void EnableSettingsModal()
        {
            PauseSingleton.Pause();
            _settingsModal.Activate();
        }

        private void DisableSettingsModal()
        {
            PauseSingleton.Unpause();
            _settingsModal.Deactivate();
        }
        
        private void GetStatsPanel(TowerController controller)
        {
            _shopPanel.Deactivate();
            _startWaveContainer.Deactivate();
            _upgradePanel.Activate();
        }

        private void GetShopPanel()
        {
            _shopPanel.Activate();
            _startWaveContainer.Activate();
            _upgradePanel.Deactivate();
        }
        
        private void GetShopPanel(TowerController controller)
        {
            GetShopPanel();
        }
    }
}