using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "TowerStatConfig", menuName = "Settings/Configs/TowerStatConfig")]
    public class TowerStatConfig : ScriptableObject
    {
        public float cost;
        public float range;
        public float damage;
    }
}