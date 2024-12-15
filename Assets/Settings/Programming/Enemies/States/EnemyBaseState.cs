using Settings.Programming.Enums;

namespace Settings.Programming.Enemies.States
{
    public abstract class EnemyBaseState
    {
        public EnemyStateType StateType { get; protected set; }
        
        protected readonly EnemyController EnemyController;

        protected EnemyBaseState(EnemyController enemyController, EnemyStateType stateType)
        {
            EnemyController = enemyController;
            StateType = stateType;
        }
        
        public virtual void Update()
        {
            TransitionConditions();
        }
        
        public abstract void Enter();
        protected abstract void Exit();
        
        protected abstract void TransitionConditions();

        protected void TransitionTo(EnemyStateType stateType)
        {
            EnemyController.State.Exit();
            EnemyController.State = EnemyController.Factory.GetState(stateType);
            EnemyController.State.Enter();
        }
    }
}