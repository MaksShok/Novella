using _Project.Scripts.Misc;

namespace _Project.Scripts.QuestModule.Task
{
    public interface ICondition
    {
        IReadOnlyReactiveProperty<bool> Status { get; }
    }
}