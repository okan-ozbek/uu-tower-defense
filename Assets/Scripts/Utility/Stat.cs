using System;

namespace Utility
{
    public struct Stat<T>
    {
        public event Action<T> OnValueChanged;
    
        private T _value;
    
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public Stat(T value) : this()
        {
            Value = value;
        }
    }
}