using System;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class SettingsController : Controller<Settings>
    {
        public static event Action<Settings> OnInitializeSettings;
        public static event Action<Settings> OnCancelSettings;
        
        // TODO there are OnValueChanged events on sliders, use them instead of the button
        // TODO make it so the sliders are updated when the settings are changed
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider soundEffectsSlider;
        [SerializeField] private Slider musicVolumeSlider;
        
        protected override void Subscribe()
        {
            ButtonController.OnApplySettingsClicked += HandleApplySettings;
            ButtonController.OnCancelSettingsClicked += HandleCancelSettings;
        }
        
        protected override void Unsubscribe()
        {
            ButtonController.OnApplySettingsClicked -= HandleApplySettings;
            ButtonController.OnCancelSettingsClicked -= HandleCancelSettings;
        }

        private void Start()
        {
            OnInitializeSettings?.Invoke(Model);
        }
        
        private void HandleApplySettings()
        {
            Model.MusicVolume.Value = musicVolumeSlider.value;
            Model.SoundEffects.Value = soundEffectsSlider.value;
            Model.MasterVolume.Value = masterVolumeSlider.value;
        }

        private void HandleCancelSettings()
        {
            OnCancelSettings?.Invoke(Model);
        }
    }
}