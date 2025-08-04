using _Project.Scripts.MiniGameModule;
using _Project.Scripts.MiniGameModule.AIGameAssistant;
using _Project.Scripts.MiniGameModule.StateOfGame;
using _Project.Scripts.MiniGameModule.TicTacToePopup;
using _Project.Scripts.MiniGameModule.TicTacToePopup.Cell;
using Zenject;

namespace _Project.Scripts.InstallModule
{
    public class MiniGameModuleInstaller : Installer<MiniGameModuleInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<TicTacToeGameBootstrapper>().AsSingle();
            Container.Bind<GridData>().AsSingle();
            Container.Bind<MoveStrategy>().AsSingle().NonLazy();
            
            Container.Bind<IGameValidator>().To<GameValidator>().AsSingle();
            Container.Bind<IAIAssistant>().To<AIAssistant>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameStateInfo>().AsSingle()
                .WithArguments(CellValue.Cross, CellValue.Zero, true);
            Container.BindInterfacesAndSelfTo<GameState>().AsSingle();
        }
    }
} 