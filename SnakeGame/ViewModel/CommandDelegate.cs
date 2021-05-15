using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SnakeGame.ViewModel
{
    public class CommandDelegate : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        public CommandDelegate(Action<object> execute)
        {
            _execute = execute;
            _canExecute = (x) => { return true; };
        }
        public CommandDelegate(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
