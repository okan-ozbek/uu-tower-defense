using System;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.EventSystems;
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
        [SerializeField] private AudioClip clickAudioClip;
        [SerializeField] private AudioClip hoverAudioClip;
        
        private void Start()
        {
            foreach (GameObject tower in towerPrefabs)
            {
                GameObject instance = Instantiate(buttonPrefab, buttonParent.transform.position, Quaternion.identity);
                instance.transform.SetParent(buttonParent.transform);
                instance.GetComponent<Image>().sprite = tower.GetComponent<Tower>().Icon;

                Button button = instance.GetComponent<Button>();
                AudioSource audioSource = GetComponent<AudioSource>();

                AddButtonListeners(button, audioSource, tower);
                AddEventTrigger(instance, audioSource);
                
                OnButtonCreated?.Invoke(instance, tower.GetComponent<Tower>());
            }
        }
        
        private void OnClickShopTowerButton(GameObject tower)
        {
            OnShopTowerClicked?.Invoke(tower);
        }

        private void AddButtonListeners(Button button, AudioSource audioSource, GameObject tower)
        {
            button.onClick.AddListener(() => OnClickShopTowerButton(tower));
            button.onClick.AddListener(() => audioSource.PlayOneShot(clickAudioClip));
        }
        
        private void AddEventTrigger(GameObject instance, AudioSource audioSource)
        {
            EventTrigger trigger = instance.GetComponent<EventTrigger>() ?? instance.AddComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerEnter
            };
            entry.callback.AddListener((value) => audioSource.PlayOneShot(hoverAudioClip));
            trigger.triggers.Add(entry);
        }
    }
}