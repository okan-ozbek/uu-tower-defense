using UnityEngine;

namespace Configs.Projectiles
{
    public abstract class ProjectileConfig : ScriptableObject
    {
        public float speed;
        public float damage;
    }
}