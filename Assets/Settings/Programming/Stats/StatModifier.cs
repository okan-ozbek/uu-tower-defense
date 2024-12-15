﻿using Settings.Programming.Enums;
using Settings.Programming.Factories;

namespace Settings.Programming.Stats
{
    public class StatModifier
    {
        public StatType Type { get; }
        public bool IsExpired => _elapsedTime >= _duration;
        
        private readonly float _value;
        private readonly float _duration;
        private readonly OperatorType _operatorType;
        private readonly OperatorStrategyFactory _operatorStrategy;
        
        private float _elapsedTime;
        
        public StatModifier(float value, float duration, StatType statType, OperatorType operatorType)
        {
            _operatorStrategy = new OperatorStrategyFactory();
            
            _value = value;
            _duration = duration;
            _operatorType = operatorType;
            Type = statType;
        }

        public float Calculate(float queryValue)
        {
            return _operatorStrategy.GetOperator(_operatorType).Calculate(queryValue, _value);
        }

        public void Update(float deltaTime)
        {
            _elapsedTime += deltaTime;
        }
    }
}