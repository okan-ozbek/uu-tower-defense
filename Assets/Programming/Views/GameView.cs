using Programming.Models;
using TMPro;
using UnityEngine;

namespace Programming.Views
{
    [RequireComponent(typeof(GameModel))]
    public class GameView : View<GameModel>
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text moneyText;

        protected override void Start()
        {
            base.Start();
            
            UpdateHealthText();
            UpdateMoneyText();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                model.Health.Value -= 10.0f;
                model.Money.Value -= 1.0f;
            }
        }

        protected override void Subscribe()
        {
            model.Health.OnValueChanged += UpdateHealthText;
            model.Money.OnValueChanged += UpdateMoneyText;
        }
        
        protected override void Unsubscribe()
        {
            model.Health.OnValueChanged -= UpdateHealthText;
            model.Money.OnValueChanged -= UpdateMoneyText;
        }
        
        private void UpdateHealthText()
        {
            healthText.text = $"{model.Health.Value}";
        }
        
        private void UpdateMoneyText()
        {
            moneyText.text = $"${model.Money.Value}";
        }
    }
}