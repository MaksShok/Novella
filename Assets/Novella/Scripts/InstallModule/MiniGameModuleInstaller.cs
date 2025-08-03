using Novella.Scripts.MiniGameModule;
using Novella.Scripts.MiniGameModule.AIGameAssistant;
using Novella.Scripts.MiniGameModule.StateOfGame;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;
using Zenject;

namespace Novella.Scripts.InstallModule
{
    public class MiniGameModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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