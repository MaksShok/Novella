using System.Collections.Generic;
using _Project.Scripts.ConditionModule.Task;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public UIConfig UIConfig;
        public List<TaskInfo> TasksInfo;
    }
}