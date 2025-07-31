using System;

namespace Novella.Scripts.Misc
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
    }

    public interface IReadOnlyReactiveProperty<TValue>
    {
        public TValue Value { get; } 
        public event Action<TValue> OnValueChange;
    }
}