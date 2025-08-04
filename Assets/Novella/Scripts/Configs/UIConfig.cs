using Novella.Scripts.MiniGameModule.SybmolSelectPopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using UnityEngine;

namespace Novella.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "ScriptableObjects/UIConfig")]
    public class UIConfig : ScriptableObject
    {
        public TicTacToeGridView GridViewPrefab;
        public GameSymbolSelector SymbolSelectorPrefab;
    }
}