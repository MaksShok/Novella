using Zenject;

namespace Novella.Scripts.InstallModule
{
    public class ProjectInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GamePrefabFactory>().AsSingle();
        }
    }
}