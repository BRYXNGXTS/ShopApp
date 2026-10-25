using System;
using System.Windows.Input;

namespace ShopApp
{
    public class MiComando : ICommand
    {
        Action _action;
        private readonly Func<bool> _canExecute;

        public event EventHandler? CanExecuteChanged;

        public MiComando(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute();
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}