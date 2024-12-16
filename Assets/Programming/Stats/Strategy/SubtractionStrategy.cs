namespace Settings.Programming.Strategies
{
    public class SubtractionStrategy : IOperatorStrategy
    {
        public float Calculate(float a, float b)
        {
            return a - b;
        }
    }
}