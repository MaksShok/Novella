using Novella.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace Novella.Scripts.InstallModule
{
    public class GameInstaller: MonoInstaller
    {
        [SerializeField] private RectTransform _uiRootPrefab;
        [SerializeField] private LevelConfig _levelConfig;
        
        public override void InstallBindings()
        {
            BindUIRoot();

            Container.Bind<LevelConfig>().FromInstance(_levelConfig);
            Container.Bind<GamePrefabFactory>().AsSingle();
            
            MiniGameModuleInstaller.Install(Container);
        }

        private void BindUIRoot()
        {
            RectTransform uiRoot = Container.InstantiatePrefab(_uiRootPrefab)
                .GetComponent<RectTransform>();
            Container.Bind<RectTransform>().FromInstance(uiRoot);
        }
    }
}