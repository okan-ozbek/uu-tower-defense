using System;
using Programming.Models;
using TMPro;
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
        
        protected override void Awake()
        {
            base.Awake();
            
            SetupButtons();
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

            }
        }

        private void SelectTower(GameObject tower)
        {
            OnSelectedTower?.Invoke(tower);
        }
    }
}