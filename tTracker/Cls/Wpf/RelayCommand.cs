using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Dek.Cls.Wpf
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> m_Execute;
        private readonly Predicate<object> m_CanExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            m_Execute = execute;
            m_CanExecute = canExecute;}

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.m_CanExecute == null || this.m_CanExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            this.m_Execute(parameter);
        }

        #endregion ICommand Members
    }
}