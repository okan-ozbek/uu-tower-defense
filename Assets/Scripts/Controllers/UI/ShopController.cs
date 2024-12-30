using System;
using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class ShopController : MonoBehaviour
    {
        public static event Action<GameObject> OnShopTowerClicked;
        public static event Action<GameObject, Tower> OnButtonCreated;

        [SerializeField] private GameObject buttonParent;
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private List<GameObject> towerPrefabs;
        
        private void Start()
        {
            foreach (GameObject tower in towerPrefabs)
            {
                GameObject instance = Instantiate(buttonPrefab, buttonParent.transform.position, Quaternion.identity);
                instance.transform.SetParent(buttonParent.transform);
                instance.GetComponentInChildren<TextMeshProUGUI>().text = tower.name;
                instance.GetComponent<Button>().onClick.AddListener(() => OnClickShopTowerButton(tower));
                
                OnButtonCreated?.Invoke(instance, tower.GetComponent<Tower>());
            }
        }
        
        private void OnClickShopTowerButton(GameObject tower)
        {
            OnShopTowerClicked?.Invoke(tower);
        }
    }
}