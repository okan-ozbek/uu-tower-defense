using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Enemies.States
{
    public sealed class EnemyStartState : EnemyBaseState
    {
        public EnemyStartState(EnemyController enemyController) : base(enemyController, EnemyStateType.Start) { }

        public override void Enter()
        {
            Debug.Log($"Current state: {GetType().Name}");
        }

        protected override void Exit()
        {
            
        }

        protected override void TransitionConditions()
        {
            if (EnemyController.WaypointContainer.PassedFirstWaypoint())
            {
                TransitionTo(EnemyStateType.InProgress);
            }
            
            if (EnemyController.Stats.IsAlive() == false)
            {
                TransitionTo(EnemyStateType.Death);
            }
        }
    }
}