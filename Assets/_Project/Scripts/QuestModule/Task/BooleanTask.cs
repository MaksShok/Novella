using _Project.Scripts.Misc;

namespace _Project.Scripts.QuestModule.Task
{
    public class BooleanTask : ICondition
    {
        public IReadOnlyReactiveProperty<bool> Status => _isComplete;
        private ReactiveProperty<bool> _isComplete = new();
        
        public TaskInfo TaskInfo { get; }

        public BooleanTask(TaskInfo taskInfo)
        {
            TaskInfo = taskInfo;
        }

        public void SetTaskComplete()
        {
            _isComplete.Value = true;
        }
    }
}