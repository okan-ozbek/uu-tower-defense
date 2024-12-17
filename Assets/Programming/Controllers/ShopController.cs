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
            
            foreach (GameObject tower in model.towers)
            {
                GameObject button = Instantiate(model.button, transform);
                button.transform.parent = transform;
                
                button.GetComponentInChildren<TextMeshProUGUI>().text = tower.name;
                button.GetComponent<Button>().onClick.AddListener(() => SelectTower(tower));
            }
        }

        private void SelectTower(GameObject tower)
        {
            OnSelectedTower?.Invoke(tower);
        }
    }
}