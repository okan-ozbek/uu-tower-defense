using System;
using System.Collections.Generic;
using Programming.Models;
using Programming.Utility.Enums;
using TMPro;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.UI;

namespace Programming.Controllers
{
    [RequireComponent(
        requiredComponent:  typeof(ShopModel)
    )]
    public class ShopController : Controller<ShopModel>
    {
        public static event Action<GameObject> OnSelectedTower;

        private Dictionary<int, GameObject> _buttons = new();
        private GameController _gameController;
        
        protected override void Awake()
        {
            base.Awake();
            
            SetupButtons();
            
            _gameController = GameObject.FindWithTag(Tags.GameController.ToString()).GetComponent<GameController>();
        }

        private void Update()
        {
            CheckBudget();
        }

        private void SetupButtons()
        {
            const float offset = 50.0f;
            
            for (int index = 0; index < model.towers.Count; index++)
            {
                GameObject button = Instantiate(model.button, new Vector2(transform.position.x, transform.position.y - (index * offset)), Quaternion.identity, transform);
                
                button.transform.parent = transform;
                button.GetComponentInChildren<TextMeshProUGUI>().text = model.towers[index].name;

                int indexCopy = index;
                button.GetComponent<Button>().onClick.AddListener(() => SelectTower(model.towers[indexCopy]));
                _buttons.Add(index, button);
            }
        }

        private void CheckBudget()
        {
            foreach (var button in _buttons)
            {
                float cost = model.towers[button.Key].GetComponent<TowerModel>().Cost;
                float budget = _gameController.model.Money.Value;

                button.Value.GetComponent<Button>().interactable = (cost <= budget);
            }
        }

        private void SelectTower(GameObject tower)
        {
            OnSelectedTower?.Invoke(tower);
        }
    }
}