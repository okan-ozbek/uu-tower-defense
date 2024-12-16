using UnityEngine;

namespace Settings.Programming.Player
{
    public class DefensiveObjectController : BaseObjectController
    {
        public GameObject interactablePrefab;
        
        public void Awake()
        {
            InitializeObject();
        }

        private void FixedUpdate()
        {
            // TODO: only places at 1 place, kinda boring
            LookAtTarget(null);
            AttackStrategy.Use(interactablePrefab);
        }
    }
}