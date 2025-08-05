using System.Collections.Generic;
using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.ConditionModule.Task
{
    public class CurrentTaskProvider
    {
        private readonly Dictionary<TaskTypeEnum, BooleanTask> _taskConditions;

        public CurrentTaskProvider(LevelConfig levelConfig)
        {
            _taskConditions = new Dictionary<TaskTypeEnum, BooleanTask>();

            foreach (var taskInfo in levelConfig.TasksInfo)
            {
                _taskConditions.Add(taskInfo.Enum, new BooleanTask(taskInfo));
            }
        }

        public bool AllTaskIsCompleted()
        {
            foreach (var task in _taskConditions.Values)
            {
                if (!task.Status.Value)
                {
                    return false;
                }
            }
            
            return true;
        }

        public void SetCompleteTask(TaskTypeEnum taskType)
        {
            if (!_taskConditions.TryGetValue(taskType, out var task))
            {
                Debug.LogError($"Can't find in task with type = '{taskType}'");
                return;
            }

            task.SetTaskComplete();
        }
    }
}