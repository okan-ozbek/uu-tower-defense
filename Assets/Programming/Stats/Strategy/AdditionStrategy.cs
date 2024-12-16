namespace Settings.Programming.Strategies
{
    public class AdditionStrategy : IOperatorStrategy
    {
        public float Calculate(float a, float b)
        {
            return a + b;
        }
    }
}