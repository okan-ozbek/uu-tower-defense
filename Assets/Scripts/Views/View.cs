using UnityEngine;

namespace Views
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private GameObject view;
        
        private void OnEnable()
        {
            Subscribe();
        }
    
        private void OnDisable()
        {
            Unsubscribe();
        }

        public void Activate()
        {
            (view ? view : gameObject).SetActive(true);
        }

        public void Deactivate()
        {
            (view ? view : gameObject).SetActive(false);
        }
    
        protected abstract void Subscribe();
        protected abstract void Unsubscribe();
    }
}
