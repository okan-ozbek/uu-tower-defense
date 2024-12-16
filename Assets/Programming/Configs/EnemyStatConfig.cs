using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "EnemyStatConfig", menuName = "Settings/Configs/EnemyStatConfig")]
    public class EnemyStatConfig : ScriptableObject
    {
        public float health;
        public float damage;
        public float speed;
        public float money;
    }
}