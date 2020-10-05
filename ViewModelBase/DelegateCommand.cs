using System;
using System.Windows.Input;

namespace NativeMVVMBase
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object>     _executeAction;
        private readonly Func<object, bool> _canExecuteAction;
        public event EventHandler           CanExecuteChanged;
        public DelegateCommand(Action<Object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction ?? throw new NullReferenceException("execute action cannot be null");
            _canExecuteAction = canExecuteAction;
        }
        public bool CanExecute(object parameter)
            => _canExecuteAction?.Invoke(parameter) ?? true;
        public void InvokeCanExecuteChanged()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public void Execute(object parameter)
            => _executeAction(parameter);
    }
}
