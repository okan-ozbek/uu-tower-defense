using Controllers.Towers;
using Controllers.Towers.Attacks;
using Controllers.UI;
using Models;
using UnityEngine;

namespace Singletons
{
    public class AudioSingleton : Singleton<AudioSingleton>
    {
        [SerializeField] private AudioSource mainTheme;
        [SerializeField] private AudioSource towerPlacementSFX;
        [SerializeField] private AudioSource towerShotSFX;

        private void OnEnable()
        {
            SettingsController.OnInitializeSettings += HandleInitializeSettings;
            Settings.OnMusicVolumeChanged += HandleMusicVolumeChanged;
            Settings.OnSoundEffectsChanged += HandleSoundEffectsChanged;
            TowerPlacementController.OnTowerPlaced += HandleTowerPlaced;
            AttackStrategy.OnAttack += HandleTowerShot;
        }

        private void OnDisable()
        {
            SettingsController.OnInitializeSettings -= HandleInitializeSettings;
            Settings.OnMusicVolumeChanged -= HandleMusicVolumeChanged;
            Settings.OnSoundEffectsChanged -= HandleSoundEffectsChanged;
            TowerPlacementController.OnTowerPlaced -= HandleTowerPlaced;
            AttackStrategy.OnAttack -= HandleTowerShot;
        }

        private void Start()
        {
            mainTheme.Play();
        }

        private void HandleMusicVolumeChanged(float value)
        {
            mainTheme.volume = value;
        }
        
        private void HandleSoundEffectsChanged(float value)
        {
            towerPlacementSFX.volume = value;
        }
        
        private void HandleInitializeSettings(Settings settings)
        {
            mainTheme.volume = settings.MusicVolume.Value;
            towerPlacementSFX.volume = settings.SoundEffects.Value;
            towerShotSFX.volume = settings.SoundEffects.Value;
        }

        private void HandleTowerPlaced(Tower tower)
        {
            towerPlacementSFX.Play();
        }
        
        private void HandleTowerShot()
        {
            towerShotSFX.time = 0f;
            towerShotSFX.pitch = Random.Range(0.9f, 1.1f);
            towerShotSFX.Play();
        }
    }
}