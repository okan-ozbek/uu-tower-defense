using UnityEngine;

namespace Settings.Programming.Player.Strategy
{
    public class InteractableStrategy : IAttackStrategy
    {
        private readonly BaseObjectController _objectController;
        
        public InteractableStrategy(BaseObjectController objectController)
        {
            _objectController = objectController;
        }

        public void Use(GameObject target)
        {
            if (target && _objectController.Stats.HasReloaded)
            {
                Debug.Log($"Placed interactable");
                PlaceInteractable(target);
                _objectController.Stats.ResetReloadTime();
            }
            
        }
        
        private void PlaceInteractable(GameObject target)
        {
            Object.Instantiate(target, _objectController.GetClosestWaypoint().position, Quaternion.identity);
        }
    }
}