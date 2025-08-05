using System;

namespace _Project.Scripts.Misc
{
    public class ReactiveProperty<TValue> : IReadOnlyReactiveProperty<TValue>
    {
        private TValue _value;

        public TValue Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    OnValueChange?.Invoke(_value);
                }
            }
        }

        public event Action<TValue> OnValueChange;
        
        public ReactiveProperty(TValue startValue = default)
        {
            _value = startValue;
        }
    }

    public interface IReadOnlyReactiveProperty<TValue>
    {
        public TValue Value { get; } 
        public event Action<TValue> OnValueChange;
    }
}