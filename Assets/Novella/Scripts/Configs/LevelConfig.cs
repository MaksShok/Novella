using System.Collections.Generic;
using Novella.Scripts.QuestModule.Task;
using UnityEngine;

namespace Novella.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public UIConfig UIConfig;
        public List<TaskInfo> TasksInfo;
    }
}