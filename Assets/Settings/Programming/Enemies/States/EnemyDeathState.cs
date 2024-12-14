using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Enemies.States
{
    public sealed class EnemyDeathState : EnemyBaseState
    {
        public EnemyDeathState(EnemyController enemyController) : base(enemyController, EnemyStateType.Death) { }

        public override void Enter()
        {
            Debug.Log($"Current state: {GetType().Name}");
            
            EnemyController.OnDeathEvent();
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