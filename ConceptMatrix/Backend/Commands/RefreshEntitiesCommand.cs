using ConceptMatrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConceptMatrix.Backend.Commands
{
    public class RefreshEntitiesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private BaseModel entityListViewModel;

        public RefreshEntitiesCommand(BaseModel baseModel)
        {
            entityListViewModel = baseModel;
        }

        public bool CanExecute(object parameter)
        {
            return !MainWindow.GameProcess.BaseProcess.HasExited;
        }

        public void Execute(object parameter)
        {
            entityListViewModel.Refresh();
        }
    }
}
