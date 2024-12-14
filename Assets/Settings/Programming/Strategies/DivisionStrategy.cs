namespace Settings.Programming.Strategies
{
    public class DivisionStrategy : IOperatorStrategy
    {
        public float Calculate(float a, float b)
        {
            return a / b;
        }
    }
}