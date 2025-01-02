using Controllers.Projectiles;
using Controllers.Towers;
using Controllers.Towers.Attacks;
using Controllers.UI;
using Models;
using UnityEngine;

namespace Singletons
{
    public class AudioSingleton : Singleton<AudioSingleton>
    {
        [SerializeField] private AudioSource soundEffectPrefab;
        [SerializeField] private AudioSource mainTheme;

        [SerializeField] private AudioClip towerPlacementSFX;
        [SerializeField] private AudioClip towerShotSFX;
        [SerializeField] private AudioClip explosionSFX;

        private float _sfxVolume;
        
        private void OnEnable()
        {
            SettingsController.OnInitializeSettings += HandleInitializeSettings;
            Settings.OnMusicVolumeChanged += HandleMusicVolumeChanged;
            Settings.OnSoundEffectsChanged += HandleSoundEffectsChanged;
            TowerPlacementController.OnTowerPlaced += HandleTowerPlaced;
            AttackStrategy.OnAttack += HandleTowerShot;
            ExplosiveProjectileController.OnExplosion += HandleExplosion;
        }

        private void OnDisable()
        {
            SettingsController.OnInitializeSettings -= HandleInitializeSettings;
            Settings.OnMusicVolumeChanged -= HandleMusicVolumeChanged;
            Settings.OnSoundEffectsChanged -= HandleSoundEffectsChanged;
            TowerPlacementController.OnTowerPlaced -= HandleTowerPlaced;
            AttackStrategy.OnAttack -= HandleTowerShot;
            ExplosiveProjectileController.OnExplosion -= HandleExplosion;
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
            _sfxVolume = value;
        }
        
        private void HandleInitializeSettings(Settings settings)
        {
            mainTheme.volume = settings.MusicVolume.Value;
            _sfxVolume = settings.SoundEffects.Value;
        }

        private void HandleTowerPlaced(Tower tower)
        {
            PlaySoundEffect(towerPlacementSFX);
        }
        
        private void HandleTowerShot()
        {
            PlaySoundEffect(towerShotSFX, Random.Range(0.75f, 1.25f), 0.75f);
        }

        private void HandleExplosion()
        {
            PlaySoundEffect(explosionSFX, Random.Range(0.75f, 1.25f), 1.8f);
        }
        
        private void PlaySoundEffect(AudioClip soundEffect, float pitch = 1.0f, float? length = null)
        {
            AudioSource instance = Instantiate(soundEffectPrefab, transform.position, Quaternion.identity);
            instance.clip = soundEffect;
            instance.volume = _sfxVolume;
            instance.pitch = pitch;
            instance.Play();
            
            Destroy(instance.gameObject, length ?? instance.clip.length);
        }
    }
}