using System.Collections.Generic;
using System.Linq;

namespace Settings.Programming.Stats
{
    public class StatMediator
    {
        private readonly List<StatModifier> _statModifiers = new List<StatModifier>();
        
        public void Add(StatModifier statModifier)
        {
            _statModifiers.Add(statModifier);
        }

        public float Modify(StatQuery query)
        {
            float value = query.Value;
            
            foreach (StatModifier statModifier in _statModifiers.Where(statModifier => statModifier.Type == query.Type))
            {
                value = statModifier.Calculate(query.Value);
            }
            
            return value;
        }

        public void Update(float deltaTime)
        {
            foreach (StatModifier statModifier in _statModifiers)
            {
                statModifier.Update(deltaTime);
            }
            
            _statModifiers.RemoveAll(statModifier => statModifier.IsExpired);
        }
    }
}