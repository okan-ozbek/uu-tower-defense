using UnityEngine;

namespace Singletons
{
    public class Singleton : MonoBehaviour
    {
     	public static Singleton Instance { get; private set; }

        private void Awake ()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad (gameObject);
            } else {
                Destroy (gameObject);
            }
        }   
    }
}