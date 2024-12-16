using Settings.Programming.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Programming.Configs
{
    [CreateAssetMenu(fileName = "InteractableConfig", menuName = "Settings/Configs/InteractableConfig")]
    public class InteractableConfig : ScriptableObject
    {
        public float modification;
        public float duration;
        public StatType statType;
        [FormerlySerializedAs("mathType")] public OperatorType operatorType;
    }
}