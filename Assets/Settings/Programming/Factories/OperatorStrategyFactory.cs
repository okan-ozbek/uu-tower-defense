using System.Collections.Generic;
using Settings.Programming.Enums;
using Settings.Programming.Strategies;
using MultiplicationStrategy = Settings.Programming.Strategies.MultiplicationStrategy;

namespace Settings.Programming.Factories
{
    public class OperatorStrategyFactory
    {
        private Dictionary<OperatorType, IOperatorStrategy> _strategies = new();
        
        public OperatorStrategyFactory()
        {
            _strategies[OperatorType.Addition] = new AdditionStrategy();
            _strategies[OperatorType.Subtraction] = new SubtractionStrategy();
            _strategies[OperatorType.Multiplication] = new MultiplicationStrategy();
            _strategies[OperatorType.Division] = new DivisionStrategy();
        }
        
        public IOperatorStrategy GetOperator(OperatorType type)
        {
            return _strategies[type];
        }
    }
}