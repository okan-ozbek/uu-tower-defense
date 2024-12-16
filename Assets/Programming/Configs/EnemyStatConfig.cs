using UnityEngine;

namespace Settings.Programming.Configs
{
    [CreateAssetMenu(fileName = "EnemyStatConfig", menuName = "Settings/Configs/EnemyStatConfig")]
    public class EnemyStatConfig : ScriptableObject
    {
        public float health;
        public float attack;
        public float speed;
    }
}