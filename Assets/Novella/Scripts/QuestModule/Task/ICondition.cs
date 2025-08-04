using Novella.Scripts.Misc;

namespace Novella.Scripts.QuestModule.Task
{
    public interface ICondition
    {
        IReadOnlyReactiveProperty<bool> Status { get; }
    }
}