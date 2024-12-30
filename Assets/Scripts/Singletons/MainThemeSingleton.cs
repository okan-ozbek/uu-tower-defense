using Controllers.UI;
using Models;
using UnityEngine;

namespace Singletons
{
    public class MainThemeSingleton : Singleton<MainThemeSingleton>
    {
        [SerializeField] private AudioSource audioSource;

        private void OnEnable()
        {
            SettingsController.OnInitializeSettings += HandleInitializeSettings;
            Settings.OnMusicVolumeChanged += HandleVolumeChange;
        }

        private void OnDisable()
        {
            SettingsController.OnInitializeSettings -= HandleInitializeSettings;
            Settings.OnMusicVolumeChanged -= HandleVolumeChange;
        }

        private void Start()
        {
            audioSource.Play();
        }

        private void HandleVolumeChange(float value)
        {
            audioSource.volume = value;
        }
        
        private void HandleInitializeSettings(Settings settings)
        {
            audioSource.volume = settings.MusicVolume.Value;
        }
    }
}