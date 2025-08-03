using System.Collections.Generic;
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
            Container.Bind<IGameValidator>().To<GameValidator>().AsSingle();
            Container.Bind<IAIAssistant>().To<AIAssistant>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameState>().AsSingle()
                .WithArguments(CellValue.Cross, CellValue.Zero, true);
            
            Container.Bind<IReadOnlyList<GridCellModel>>()
                .FromResolveGetter<GridData>(d => d.CellModels);
        }
    }
} 