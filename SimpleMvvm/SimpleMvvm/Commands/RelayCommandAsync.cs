using System.Windows.Input;

namespace SimpleMvvm.Commands
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other objects by invoking delegates.
    /// The default return value for the CanExecute method is 'true'.
    /// </summary>
    public class RelayCommandAsync : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommandAsync(Func<Task> execute)
            : this(execute, null)
        {
        }

        public RelayCommandAsync(Func<Task> execute, Func<bool> canExecute)
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

        public async void Execute(object parameter)
        {
            if(_canExecute())
                await _execute();
        }

        public event EventHandler CanExecuteChanged;
    }

    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other objects by invoking delegates.
    /// The default return value for the CanExecute method is 'true'.
    /// </summary>
    /// <typeparam name="T"> The type of the parameter passed to the delegates. </typeparam>
    public class RelayCommandAsync<T> : ICommand
    {
        private readonly Func<T, Task> _execute;
        private readonly Func<T, bool> _canExecute;

        public RelayCommandAsync(Func<T, Task> execute)
            : this(execute, null)
        {
        }

        public RelayCommandAsync(Func<T, Task> execute, Func<T, bool> canExecute)
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

        public async void Execute(object parameter)
        {
            if(_canExecute((T)parameter))
                await _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
