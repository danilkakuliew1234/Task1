using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UITable.Model;

namespace UITable.ViewModel.Commands
{
    class CreateTableCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CreateTableFromView createTableFromView = new CreateTableFromView();

            mainWindowViewModel.Status = createTableFromView.CreateTable();

            createTableFromView.LoadTable(mainWindowViewModel.Cities.ToList());
        }

        public CreateTableCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }
    }
}
