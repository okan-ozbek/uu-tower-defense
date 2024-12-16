using System.Collections.Generic;
using Settings.Programming.Enemies;
using Settings.Programming.Enemies.States;
using Settings.Programming.Enums;

namespace Settings.Programming.Factories
{
    public class EnemyStateFactory
    {
        private readonly Dictionary<EnemyStateType, EnemyBaseState> _states = new();

        public EnemyStateFactory(EnemyController enemyController)
        {
            _states[EnemyStateType.Start] = new EnemyStartState(enemyController);
            _states[EnemyStateType.InProgress] = new EnemyInProgressState(enemyController);
            _states[EnemyStateType.Finished] = new EnemyFinishedState(enemyController);
            _states[EnemyStateType.Death] = new EnemyDeathState(enemyController);
        }
        
        public EnemyBaseState GetState(EnemyStateType stateType)
        {
            return _states[stateType];
        }
    }
}