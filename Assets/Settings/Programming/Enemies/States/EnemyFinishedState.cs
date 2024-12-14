using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Enemies.States
{
    public sealed class EnemyFinishedState : EnemyBaseState
    {
        public EnemyFinishedState(EnemyController enemyController) : base(enemyController, EnemyStateType.Finished) { }

        public override void Enter()
        {
            Debug.Log($"Current state: {GetType().Name}");
            
            EnemyController.OnFinishedEvent();
            enemyController.Destroy();
        }

        protected override void Exit()
        {
            // Useful for object pooling later on.
        }

        protected override void TransitionConditions()
        {
        }

        
    }
}