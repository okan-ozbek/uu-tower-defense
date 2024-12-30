using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public class MoneyContainer : View
    {
        [SerializeField] private TMP_Text moneyText;

        protected override void Subscribe()
        {
            Game.OnMoneyChanged += HandleHealthChanged;
        }
    
        protected override void Unsubscribe()
        {
            Game.OnMoneyChanged -= HandleHealthChanged;
        }

        private void HandleHealthChanged(float money)
        {
            moneyText.text = $"{money}";
        }
    }
}