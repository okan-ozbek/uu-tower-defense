using Settings.Programming.Enums;
using Settings.Programming.Factories;
using System;

namespace Settings.Programming.Stats
{
    public class Stat<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        private readonly StatMediator _mediator;
        private readonly StatType _statType;
        private readonly bool _matchBaseValue;

        private T _baseValue;
        private T _currentValue;

        private T BaseValue
        {
            get
            {
                StatQuery query = new StatQuery(Convert.ToSingle(_baseValue), _statType);
                return (T)Convert.ChangeType(_mediator.Modify(query), typeof(T));
            }
            set => _baseValue = value;
        }

        public T GetCurrentValue()
        {
            _currentValue = (_matchBaseValue) ? BaseValue : GetCurrentValueNotExceededBaseValue();
            return _currentValue;
        }

        public void SetCurrentValue(T amount, OperatorType operatorType)
        {
            _currentValue = (T)Convert.ChangeType(OperatorStrategyFactory.Create(operatorType).Calculate(Convert.ToSingle(_currentValue), Convert.ToSingle(amount)), typeof(T));
            _currentValue = GetCurrentValueNotExceededBaseValue();
        }

        public Stat(StatMediator mediator, StatType statType, T baseValue, bool matchBaseValue = false)
        {
            _mediator = mediator;
            _statType = statType;

            _baseValue = baseValue;
            _currentValue = baseValue;
            _matchBaseValue = matchBaseValue;
        }

        private T GetCurrentValueNotExceededBaseValue()
        {
            return (Convert.ToSingle(_currentValue) > Convert.ToSingle(BaseValue)) ? BaseValue : _currentValue;
        }
    }
}