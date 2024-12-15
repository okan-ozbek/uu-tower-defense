namespace Settings.Programming.Strategies
{
    public class MultiplicationStrategy : IOperatorStrategy
    {
        public float Calculate(float a, float b)
        {
            return a * b;
        }
    }
}