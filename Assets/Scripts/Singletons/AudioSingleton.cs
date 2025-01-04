using Controllers.Enemies;
using Controllers.Projectiles;
using Controllers.Towers;
using Controllers.Towers.Attacks;
using Controllers.UI;
using Models;
using UnityEngine;

namespace Singletons
{
    public class AudioSingleton : MonoBehaviour
    {
        [SerializeField] private AudioSource uiSoundPrefab;
        [SerializeField] private AudioSource soundEffectPrefab;
        [SerializeField] private AudioSource mainTheme;

        [SerializeField] private AudioClip buttonClickSFX;
        [SerializeField] private AudioClip[] towerPlacementSFX;
        [SerializeField] private AudioClip[] towerShotSFX;
        [SerializeField] private AudioClip[] explosionSFX;
        [SerializeField] private AudioClip[] enemyDeathSFX;
        [SerializeField] private AudioClip[] enemyReachedEndSFX;
        [SerializeField] private AudioClip waveStartSFX;
        [SerializeField] private AudioClip waveEndSFX;

        private float _sfxVolume;
        
        private void OnEnable()
        {
            TowerPlacementController.OnTowerPlaced += HandleTowerPlaced;
            MouseSelectionController.OnTowerSelected += HandleTowerSelected;
            AttackStrategy.OnAttack += HandleTowerShot;
            ExplosiveProjectileController.OnExplosion += HandleExplosion;
            EnemyController.OnEnemyDeath += HandleEnemyDeath;
            EnemyController.OnEnemyReachedEnd += HandleEnemyReachedEnd;
            WaveSystem.OnWaveFinished += HandleWaveFinished;
            WaveSystem.OnWaveStarted += HandleWaveStarted;
        }

        private void OnDisable()
        {
            TowerPlacementController.OnTowerPlaced -= HandleTowerPlaced;
            MouseSelectionController.OnTowerSelected -= HandleTowerSelected;
            AttackStrategy.OnAttack -= HandleTowerShot;
            ExplosiveProjectileController.OnExplosion -= HandleExplosion;
            EnemyController.OnEnemyDeath -= HandleEnemyDeath;
            EnemyController.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
            WaveSystem.OnWaveFinished -= HandleWaveFinished;
            WaveSystem.OnWaveStarted -= HandleWaveStarted;
        }

        private void Start()
        {
            mainTheme.Play();
        }

        private void HandleTowerPlaced(Tower tower)
        {
            PlaySoundEffect(towerPlacementSFX);
        }
        
        private void HandleTowerShot()
        {
            PlaySoundEffect(towerShotSFX, Random.Range(0.75f, 1.25f), 0.75f);
        }
        
        private void HandleTowerSelected(TowerController controller)
        {
            PlayUISound(buttonClickSFX);
        }

        private void HandleExplosion()
        {
            PlaySoundEffect(explosionSFX, Random.Range(0.75f, 1.25f), 1.8f);
        }
        
        private void HandleEnemyDeath(Enemy enemy)
        {
            PlaySoundEffect(enemyDeathSFX, Random.Range(0.75f, 1.25f));
        }
        
        private void HandleEnemyReachedEnd(Enemy enemy)
        {
            PlaySoundEffect(enemyReachedEndSFX, Random.Range(0.75f, 1.25f));
        }
        
        private void HandleWaveFinished()
        {
            PlaySoundEffect(waveEndSFX, Random.Range(0.75f, 1.25f));
        }
        
        private void HandleWaveStarted()
        {
            PlaySoundEffect(waveStartSFX, Random.Range(0.75f, 1.25f));
        }
        
        private void PlayUISound(AudioClip soundEffect)
        {
            AudioSource instance = Instantiate(uiSoundPrefab, transform.position, Quaternion.identity);
            instance.clip = soundEffect;
            instance.Play();
            
            Destroy(instance.gameObject, instance.clip.length);
        }
        
        private void PlaySoundEffect(AudioClip[] soundEffects, float pitch = 1.0f, float? length = null)
        {
            PlaySoundEffect(soundEffects[Random.Range(0, soundEffects.Length)], pitch, length);
        }
        
        private void PlaySoundEffect(AudioClip soundEffect, float pitch = 1.0f, float? length = null)
        {
            AudioSource instance = Instantiate(soundEffectPrefab, transform.position, Quaternion.identity);
            instance.clip = soundEffect;
            instance.pitch = pitch;
            instance.Play();
            
            Destroy(instance.gameObject, length ?? instance.clip.length);
        }
    }
}