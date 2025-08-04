using _Project.Scripts.MiniGameModule.SybmolSelectPopup;
using _Project.Scripts.MiniGameModule.TicTacToePopup;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "ScriptableObjects/UIConfig")]
    public class UIConfig : ScriptableObject
    {
        public TicTacToeGridView GridViewPrefab;
        public GameSymbolSelector SymbolSelectorPrefab;
    }
}