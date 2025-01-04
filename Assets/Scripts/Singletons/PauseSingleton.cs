using UnityEngine;

namespace Singletons
{
    public class PauseSingleton : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }
        
        private void Start()
        {
            IsPaused = false;
        }

        public static void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0;
        }

        public static void Unpause()
        {
            IsPaused = false;
            Time.timeScale = 1;
        }
    }
}