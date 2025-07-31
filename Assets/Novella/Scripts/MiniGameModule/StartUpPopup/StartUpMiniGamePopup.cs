using System;
using UnityEngine;
using UnityEngine.UI;

namespace Novella.Scripts.MiniGameModule.StartUpPopup
{
    public class StartUpMiniGamePopup: MonoBehaviour
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
            
        }

        private void ZeroButtonPressed()
        {
            
        }
    }
}