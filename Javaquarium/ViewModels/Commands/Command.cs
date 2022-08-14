using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Javaquarium.ViewModels.Commands
{
    public class Command : ICommand
    {
        private readonly Action _execute;
        public event EventHandler? CanExecuteChanged;

        public Command(Action handler)
        {
            _execute = handler;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => _execute();
    }
}
