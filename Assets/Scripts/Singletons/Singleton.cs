using UnityEngine;

namespace Singletons
{
    public abstract class Singleton : MonoBehaviour
    {
        public static Singleton Instance { get; private set; }

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    }
}