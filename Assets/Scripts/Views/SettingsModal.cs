using Controllers.UI;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class SettingsModal : View
    {
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider soundEffectsSlider;
        [SerializeField] private Slider musicVolumeSlider;
        
        protected override void Subscribe()
        {
            SettingsController.OnInitializeSettings += SetSettings;
            SettingsController.OnCancelSettings += SetSettings;
            
            masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeValueChanged);
            soundEffectsSlider.onValueChanged.AddListener(OnSoundEffectsVolumeValueChanged);
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeValueChanged);
        }

        protected override void Unsubscribe()
        {
            SettingsController.OnInitializeSettings -= SetSettings;
            SettingsController.OnCancelSettings -= SetSettings;
            
            masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeValueChanged);
            soundEffectsSlider.onValueChanged.RemoveListener(OnSoundEffectsVolumeValueChanged);
            musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeValueChanged);
        }
        
        private void SetSettings(Settings settings)
        {
            masterVolumeSlider.value = settings.MasterVolume.Value;
            soundEffectsSlider.value = settings.SoundEffects.Value;
            musicVolumeSlider.value = settings.MusicVolume.Value;
        }
        
        private void OnMasterVolumeValueChanged(float value)
        {
            soundEffectsSlider.value = Mathf.Min(soundEffectsSlider.value, value);
            musicVolumeSlider.value = Mathf.Min(musicVolumeSlider.value, value);
        }
        
        private void OnSoundEffectsVolumeValueChanged(float value)
        {
            masterVolumeSlider.value = Mathf.Max(masterVolumeSlider.value, value);
        }
        
        private void OnMusicVolumeValueChanged(float value)
        {
            masterVolumeSlider.value = Mathf.Max(masterVolumeSlider.value, value);
        }
    }
}