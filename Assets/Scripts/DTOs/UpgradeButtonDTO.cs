using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DTOs
{
    [Serializable]
    public class UpgradeButtonDTO
    {
        public float cost; 
        public GameObject buttonGameObject;

        public Button Button => buttonGameObject.GetComponent<Button>();
    }
}