using Models;
using UnityEngine;

namespace Controllers
{
    public abstract class Controller<TModel> : MonoBehaviour where TModel : Model
    {
        public TModel Model { get; private set; }

        protected virtual void Awake()
        {
            Model = GetComponent<TModel>();
        }
        
        private void OnEnable()
        {
            Subscribe();
        }
        
        private void OnDisable()
        {
            Unsubscribe();
        }

        protected virtual void Subscribe()
        {
        }
        
        protected virtual void Unsubscribe()
        {
        }
    }
}