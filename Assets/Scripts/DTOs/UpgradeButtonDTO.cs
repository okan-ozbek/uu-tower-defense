using System;
using Enums;
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
        public UpgradeButtonType upgradeButtonType;

        public Button Button => buttonGameObject.GetComponent<Button>();
    }
}