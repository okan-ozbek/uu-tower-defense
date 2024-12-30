using System;
using Models;
using UnityEngine;

namespace Singletons
{
    public class MainThemeSingleton : Singleton
    {
        [SerializeField] private AudioSource audioSource;

        private void OnEnable()
        {
            Settings.OnMasterVolumeChanged += HandleVolumeChange;
            Settings.OnMusicVolumeChanged += HandleVolumeChange;
        }

        private void OnDisable()
        {
            Settings.OnMasterVolumeChanged -= HandleVolumeChange;
            Settings.OnMusicVolumeChanged -= HandleVolumeChange;
        }

        private void Start()
        {
            audioSource.Play();
        }

        private void HandleVolumeChange(float value)
        {
            Debug.Log("Hello world");
            audioSource.volume = value;
        }
    }
}