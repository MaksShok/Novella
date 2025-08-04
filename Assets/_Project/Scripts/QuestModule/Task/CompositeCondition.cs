using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Misc;

namespace _Project.Scripts.QuestModule.Task
{
    public class CompositeCondition : ICondition
    {
        private readonly ReactiveProperty<bool> _property = new();
        private readonly List<IReadOnlyReactiveProperty<bool>> _mergedProperties;
        
        public IReadOnlyReactiveProperty<bool> Status => _property;
        
        public CompositeCondition(List<IReadOnlyReactiveProperty<bool>> mergedProperties)
        {
            _mergedProperties = mergedProperties;

            foreach (var property in _mergedProperties)
            {
                if (property != null)
                    property.OnValueChange += _ => Refresh();
            }
        }

        private void Refresh()
        {
            _property.Value = _mergedProperties.All(p => p.Value);
        }
    }
}