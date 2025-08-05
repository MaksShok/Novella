using _Project.Scripts.Misc;

namespace _Project.Scripts.ConditionModule.Task
{
    public interface ICondition
    {
        IReadOnlyReactiveProperty<bool> Status { get; }
    }
}