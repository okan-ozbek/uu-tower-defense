using System;
using Utility;

namespace Models
{
    public class Settings : Model
    {
        public static event Action<float> OnMasterVolumeChanged;
        public static event Action<float> OnSoundEffectsChanged;
        public static event Action<float> OnMusicVolumeChanged;
        
        public Stat<float> MasterVolume;
        public Stat<float> SoundEffects;
        public Stat<float> MusicVolume;

        private void Awake()
        {
            MasterVolume.OnValueChanged += (value) => OnMasterVolumeChanged?.Invoke(value);
            SoundEffects.OnValueChanged += (value) => OnSoundEffectsChanged?.Invoke(value);
            MusicVolume.OnValueChanged += (value) => OnMusicVolumeChanged?.Invoke(value);

            MasterVolume.Value = 0.3f;
            SoundEffects.Value = 0.3f;
            MusicVolume.Value = 0.3f;
        }
        
        protected override void Start()
        {
            
        }
    }
}