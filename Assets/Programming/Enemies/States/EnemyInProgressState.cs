using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Enemies.States
{
    public sealed class EnemyInProgressState : EnemyBaseState
    {
        public EnemyInProgressState(EnemyController enemyController) : base(enemyController, EnemyStateType.InProgress) { }

        public override void Enter()
        {
            Debug.Log($"Current state: {GetType().Name}");
        }

        protected override void Exit()
        {
            
        }

        protected override void TransitionConditions()
        {
            if (EnemyController.WaypointContainer.ReachedLastWaypoint())
            {
                TransitionTo(EnemyStateType.Finished);
            }

            if (EnemyController.Stats.IsAlive() == false)
            {
                TransitionTo(EnemyStateType.Death);
            }
        }
    }
}