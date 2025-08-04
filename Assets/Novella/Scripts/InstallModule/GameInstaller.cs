using UnityEngine;
using Zenject;

namespace Novella.Scripts.InstallModule
{
    public class GameInstaller: MonoInstaller
    {
        [SerializeField] private RectTransform _uiRootPrefab;
        
        public override void InstallBindings()
        {
            BindUIRoot();
            
            Container.Bind<GamePrefabFactory>().AsSingle();
        }

        private void BindUIRoot()
        {
            RectTransform uiRoot = Container.InstantiatePrefab(_uiRootPrefab)
                .GetComponent<RectTransform>();
            Container.Bind<RectTransform>().FromInstance(uiRoot);
        }
    }
}