using System;
using System.Windows.Input;

namespace SignalRServer.Models
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action execute;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }
    }
}
