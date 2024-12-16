using Programming.Models;
using UnityEngine;

namespace Programming.Views
{
    public abstract class View<TModel> : MonoBehaviour where TModel : Model
    {
        [HideInInspector] public TModel model;

        protected virtual void Start()
        {
           Subscribe(); 
        }
        
        protected virtual void OnDisable()
        {
            Unsubscribe();
        }

        protected virtual void Awake()
        {
            model = GetComponent<TModel>();
        }

        protected abstract void Subscribe();
        protected abstract void Unsubscribe();
    }
}