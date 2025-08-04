using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MiniGameModule.SybmolSelectPopup
{
    public class GameSymbolSelector: MonoBehaviour
    {
        [SerializeField] private Button _crossButton;
        [SerializeField] private Button _zeroButton;

        private void Awake()
        {
            _crossButton.onClick.AddListener(CrossButtonPressed);
            _zeroButton.onClick.AddListener(ZeroButtonPressed);
        }

        private void CrossButtonPressed()
        {
            //_symbolSelectData = new SymbolSelectData(CellValue.Cross, CellValue.Zero);
            TurnOffInput();
        }

        private void ZeroButtonPressed()
        {
            //_symbolSelectData = new SymbolSelectData(CellValue.Zero, CellValue.Cross);
            TurnOffInput();
        }

        private void TurnOffInput()
        {
            _crossButton.onClick.RemoveAllListeners();
            _zeroButton.onClick.RemoveAllListeners();
        }
    }
}