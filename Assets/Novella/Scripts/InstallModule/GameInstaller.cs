using Zenject;

namespace Novella.Scripts.InstallModule
{
    public class GameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GamePrefabFactory>().AsSingle();
        }
    }
}