using _Project.Scripts.Configs;
using _Project.Scripts.InventoryModule;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.InstallModule
{
    public class GameInstaller: MonoInstaller
    {
        [SerializeField] private UIRoot _uiRootPrefab;
        [SerializeField] private LevelConfig _levelConfig;
        
        public override void InstallBindings()
        {
            BindUIRoot();

            Container.Bind<LevelConfig>().FromInstance(_levelConfig);
            Container.Bind<GamePrefabFactory>().AsSingle();

            Container.Bind<InventoryModel>().AsSingle().WithArguments(4);
            
            MiniGameModuleInstaller.Install(Container);
        }

        private void BindUIRoot()
        {
            UIRoot uiRoot = Container.InstantiatePrefab(_uiRootPrefab)
                .GetComponent<UIRoot>();
            Container.Bind<UIRoot>().FromInstance(uiRoot);
        }
    }
}