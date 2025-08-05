using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Project.Scripts.MiniGameModule.TicTacToePopup
{
    public class TicTacToeGridView: MonoBehaviour
    {
        [SerializeField] private GridCellGenerator _gridCellGenerator;
        
        [SerializeField] private TextMeshProUGUI _stepText;
        [SerializeField] private Button _resetButton;

        private TicTacToeGridModel _model;

        private void Start()
        {
            _resetButton.onClick.AddListener(OnResetButtonClicked);
        }

        public void InitialGridModel(TicTacToeGridModel model)
        {
            _model = model;
            
            _model.WhoIsStepText.OnValueChange += UpdateText;
            UpdateText(_model.WhoIsStepText.Value);
        }

        private void UpdateText(string text)
        {
            _stepText.text = text;
        }

        private void OnResetButtonClicked()
        {
            _model.ResetGameRequest();
        }

        private void OnDestroy()
        {
            _model.WhoIsStepText.OnValueChange -= UpdateText;
        }
    }
}