using System.Collections.Generic;
using System.ComponentModel;
using Novella.Scripts.MiniGameModule.TicTacToePopup;
using Novella.Scripts.MiniGameModule.TicTacToePopup.Cell;
using Zenject;

namespace Novella.Scripts.InstallModule
{
    public class GameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GridData>().AsSingle();
            //Container.Bind<TicTacToeGridModel>().AsSingle();
            
            Container.Bind<IReadOnlyList<GridCellModel>>()
                .FromResolveGetter<GridData>(d => d.CellModels);
        }
    }
}