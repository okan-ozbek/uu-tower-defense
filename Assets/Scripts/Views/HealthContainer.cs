using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class HealthContainer : View
    {
        [SerializeField] private TMP_Text healthText;

        protected override void Subscribe()
        {
            Game.OnHealthChanged += HandleHealthChanged;
        }
    
        protected override void Unsubscribe()
        {
            Game.OnHealthChanged -= HandleHealthChanged;
        }

        private void HandleHealthChanged(float health)
        {
            healthText.text = $"{health}";
        }
    }
}