using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public float health;
        public float damage;
        public float speed;
        public float reward;
        public float cost;
    }
}