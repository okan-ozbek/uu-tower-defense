using Settings.Programming.Enums;

namespace Settings.Programming.Stats
{
    public class StatQuery
    {
        public float Value { get; }
        public StatType Type { get; }
        
        public StatQuery(float value, StatType type)
        {
            Value = value;
            Type = type;
        }
    }
}