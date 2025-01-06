using UnityEngine;
using UnityEngine.SceneManagement;

namespace Singletons
{
    public class PauseSingleton : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void Start()
        {
            IsPaused = false;
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Unpause();
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