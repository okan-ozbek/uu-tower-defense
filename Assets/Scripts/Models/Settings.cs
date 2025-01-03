using System;
using Utility;

namespace Models
{
    public class Settings : Model
    {
        public Stat<float> MasterVolume;
        public Stat<float> SoundEffects;
        public Stat<float> MusicVolume;
        public Stat<float> UIVolume;

        private void Awake()
        {
            MasterVolume.Value = 0.3f;
            SoundEffects.Value = 0.3f;
            MusicVolume.Value = 0.3f;
            UIVolume.Value = 0.3f;
        }
        
        protected override void Start()
        {
            
        }
    }
}