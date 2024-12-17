using Programming.Models;
using UnityEngine;

namespace Programming.Controllers
{
    public abstract class Controller<TModel> : MonoBehaviour where TModel : Model
    {
        [HideInInspector] public TModel model;

        protected void OnEnable()
        {
            Subscribe();
        }

        protected void OnDisable()
        {
            Unsubscribe();
        }

        protected virtual void Awake()
        {
            model = GetComponent<TModel>();
        }

        protected virtual void Subscribe() {}
        protected virtual void Unsubscribe() {}
    }
}