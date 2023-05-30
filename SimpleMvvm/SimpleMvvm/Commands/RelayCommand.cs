using System.Windows.Input;

namespace SimpleMvvm.Commands
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other objects by invoking delegates.
    /// The default return value for the CanExecute method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {   
            if(_canExecute())
                _execute();
        }

        public event EventHandler CanExecuteChanged;
    }

    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other objects by invoking delegates.
    /// The default return value for the CanExecute method is 'true'.
    /// </summary>
    /// <typeparam name="T"> The type of the parameter passed to the delegates. </typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? (p => true);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (_canExecute((T)parameter))
                _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
