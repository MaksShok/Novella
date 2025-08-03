namespace Novella.Scripts.MiniGameModule.TicTacToePopup
{
    public class TicTacToeGridModel
    {
        private readonly GridData _gridData;
        
        public string WhoIsStepText => _whoIsStepText;
        private string _whoIsStepText;

        public TicTacToeGridModel(GridData gridData)
        {
            _gridData = gridData;
        }
    }
}