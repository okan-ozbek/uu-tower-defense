﻿using System;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class SettingsController : Controller<Settings>
    {
        public static event Action<Settings> OnInitializeSettings;
        public static event Action<Settings> OnCancelSettings;
        
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider soundEffectsSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider uiVolumeSlider;

        private float _unsavedMasterVolume;
        private float _unsavedSoundEffects;
        private float _unsavedMusicVolume;
        private float _unsavedUIVolume;
        
        protected override void Subscribe()
        {
            masterVolumeSlider.onValueChanged.AddListener(value => Model.MasterVolume.Value = value);
            soundEffectsSlider.onValueChanged.AddListener(value => Model.SoundEffects.Value = value);
            musicVolumeSlider.onValueChanged.AddListener(value => Model.MusicVolume.Value = value);
            uiVolumeSlider.onValueChanged.AddListener(value => Model.UIVolume.Value = value);

            GameButtonController.OnApplySettingsClicked += HandleApplySettings;
            GameButtonController.OnCancelSettingsClicked += HandleCancelSettings;
            MenuButtonController.OnApplySettingsClicked += HandleApplySettings;
            MenuButtonController.OnCancelSettingsClicked += HandleCancelSettings;
        }
        
        protected override void Unsubscribe()
        {
            masterVolumeSlider.onValueChanged.RemoveAllListeners();
            soundEffectsSlider.onValueChanged.RemoveAllListeners();
            musicVolumeSlider.onValueChanged.RemoveAllListeners();
            uiVolumeSlider.onValueChanged.RemoveAllListeners();
            
            GameButtonController.OnApplySettingsClicked -= HandleApplySettings;
            GameButtonController.OnCancelSettingsClicked -= HandleCancelSettings;
            MenuButtonController.OnApplySettingsClicked -= HandleApplySettings;
            MenuButtonController.OnCancelSettingsClicked -= HandleCancelSettings;
        }

        private void Start()
        {
            OnInitializeSettings?.Invoke(Model);
            
            _unsavedMasterVolume = Model.MasterVolume.Value;
            _unsavedSoundEffects = Model.SoundEffects.Value;
            _unsavedMusicVolume = Model.MusicVolume.Value;
            _unsavedUIVolume = Model.UIVolume.Value;
        }
        
        private void HandleApplySettings()
        {
            Model.MusicVolume.Value = musicVolumeSlider.value;
            Model.SoundEffects.Value = soundEffectsSlider.value;
            Model.MasterVolume.Value = masterVolumeSlider.value;
            Model.UIVolume.Value = uiVolumeSlider.value;
            
            _unsavedMasterVolume = Model.MasterVolume.Value;
            _unsavedSoundEffects = Model.SoundEffects.Value;
            _unsavedMusicVolume = Model.MusicVolume.Value;
            _unsavedUIVolume = Model.UIVolume.Value;
        }

        private void HandleCancelSettings()
        {
            Model.MasterVolume.Value = _unsavedMasterVolume;
            Model.SoundEffects.Value = _unsavedSoundEffects;
            Model.MusicVolume.Value = _unsavedMusicVolume;
            Model.UIVolume.Value = _unsavedUIVolume;
            
            OnCancelSettings?.Invoke(Model);
        }
    }
}