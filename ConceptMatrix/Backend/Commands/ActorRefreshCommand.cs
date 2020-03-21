using ConceptMatrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConceptMatrix.Backend.Commands
{
    public class ActorRefreshCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private BaseModel BaseModelModel;

        public ActorRefreshCommand(BaseModel baseModel)
        {
            BaseModelModel = baseModel;
        }

        public bool CanExecute(object parameter)
        {
            return !MainWindow.GameProcess.BaseProcess.HasExited;
        }

        public void Execute(object parameter)
        {
            BaseModelModel.ActorRefresh();
        }
    }
}
