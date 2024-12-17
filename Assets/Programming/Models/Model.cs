using UnityEngine;

namespace Programming.Models
{
    public abstract class Model : MonoBehaviour
    {
        public virtual void Awake()
        {
            Initialize();
        }

        public abstract void Initialize();
    }
}