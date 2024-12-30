using Controllers.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class StartWaveContainer : View
    {
        [SerializeField] private Button startWaveButton;
        
        protected override void Subscribe()
        {
            WaveSystem.OnWaveStarted += HandleWaveStarted;
            WaveSystem.OnWaveFinished += HandleWaveFinished;
        }

        protected override void Unsubscribe()
        {
            WaveSystem.OnWaveStarted -= HandleWaveStarted;
            WaveSystem.OnWaveFinished -= HandleWaveFinished;
        }

        private void HandleWaveStarted()
        {
            startWaveButton.interactable = false;
        }

        private void HandleWaveFinished()
        {
            startWaveButton.interactable = true;
        }
    }
}