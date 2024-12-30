using UnityEngine;

namespace Singletons
{
    public class Singleton<TInstance> : MonoBehaviour where TInstance : Component
    {
        public static TInstance Instance { get; private set; }
	
        public virtual void Awake ()
        {
            if (Instance == null) {
                Instance = this as TInstance;
                DontDestroyOnLoad (this);
            } else {
                Destroy (gameObject);
            }
        }
    }
}