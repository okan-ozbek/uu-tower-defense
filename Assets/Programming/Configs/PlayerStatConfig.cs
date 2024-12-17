using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Settings/Configs/PlayerStatConfig")]
    public class PlayerStatConfig : ScriptableObject
    {
        public float health;
        public float money;
    }
}