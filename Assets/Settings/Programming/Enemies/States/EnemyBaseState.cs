using Settings.Programming.Enums;

namespace Settings.Programming.Enemies.States
{
    public abstract class EnemyBaseState
    {
        public EnemyStateType StateType { get; protected set; }
        
        protected readonly EnemyController enemyController;

        protected EnemyBaseState(EnemyController enemyController, EnemyStateType stateType)
        {
            this.enemyController = enemyController;
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
            enemyController.State.Exit();
            enemyController.State = enemyController.Factory.GetState(stateType);
            enemyController.State.Enter();
        }
    }
}