using Settings.Programming.Enums;
using Settings.Programming.Strategies;
using MultiplicationStrategy = Settings.Programming.Strategies.MultiplicationStrategy;

namespace Settings.Programming.Factories
{
    public static class OperatorStrategyFactory
    {
        public static IOperatorStrategy Create(OperatorType type)
        {
            return type switch
            {
                OperatorType.Addition => new AdditionStrategy(),
                OperatorType.Subtraction => new SubtractionStrategy(),
                OperatorType.Multiplication => new MultiplicationStrategy(),
                OperatorType.Division => new DivisionStrategy(),
                _ => null
            };
        }
    }
}