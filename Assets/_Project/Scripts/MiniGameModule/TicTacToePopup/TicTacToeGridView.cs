using TMPro;
using UnityEngine;

namespace _Project.Scripts.MiniGameModule.TicTacToePopup
{
    public class TicTacToeGridView: MonoBehaviour
    {
        [SerializeField] private GridCellGenerator _gridCellGenerator;
        [SerializeField] private TextMeshProUGUI _chooseStepText;

        private TicTacToeGridModel _model;

        public void InitialGamePopupModel(TicTacToeGridModel model)
        {
            _model = model;
            UpdateUI();
        }

        public void UpdateUI()
        {
            _chooseStepText.text = _model.WhoIsStepText;
        }
    }
}