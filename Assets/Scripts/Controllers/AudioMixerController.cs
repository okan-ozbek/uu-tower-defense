using Enums;
using UnityEngine;
using UnityEngine.Audio;

namespace Controllers
{
    public class AudioMixerController : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        
        public void SetMasterVolume(float volume)
        {
            audioMixer.SetFloat(
                AudioMixerGroupName.MasterVolume.ToString(), 
                Mathf.Log10(volume) * 20.0f
            );
        }
        
        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat(
                AudioMixerGroupName.MusicVolume.ToString(), 
                Mathf.Log10(volume) * 20.0f
            );
        }
        
        public void SetSoundEffectsVolume(float volume)
        {
            audioMixer.SetFloat(
                AudioMixerGroupName.SoundEffectsVolume.ToString(), 
                Mathf.Log10(volume) * 20.0f
            );
        }
        
        public void SetUIVolume(float volume)
        {
            audioMixer.SetFloat(
                AudioMixerGroupName.UIVolume.ToString(), 
                Mathf.Log10(volume) * 20.0f
            );
        }
    }
}