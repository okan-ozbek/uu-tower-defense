using System;
using UnityEngine;

namespace Programming.Stats
{
    public class GenericStat<TValue>
    {
        public event Action OnValueChanged;
        
        private readonly TValue _maxValue;
        private TValue _value;

        public TValue MaxValue => _maxValue;
        public TValue Value
        {
            get => _value;
            set => SetValue(value);
        }
        
        public GenericStat(TValue value)
        {
            _maxValue = value;
            _value = value;
            
            OnValueChanged = null;
        }

        private void SetValue(TValue value)
        {
            _value = (TValue)Convert.ChangeType(value, typeof(TValue));
            
            OnValueChanged?.Invoke();
        }
    }
}