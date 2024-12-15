using UnityEngine;

namespace Settings.Programming.Player
{
    public class OffensiveObjectController : BaseObjectController
    {
        public void Awake()
        {
            InitializeObject();   
        }

        private void FixedUpdate()
        {
            GameObject closestEnemy = GetClosestEnemy();
            LookAtTarget(closestEnemy);
            AttackStrategy.Use(closestEnemy);
            
            if (closestEnemy)
            {
                Debug.DrawLine(transform.position, closestEnemy.transform.position, Color.green);
            }
        }
    }
}