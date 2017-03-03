﻿using System;
using System.Windows.Input;

namespace RootNamespace.Mvvm
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute();
        public void Execute(object parameter) => this.execute();
        public void OnCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute((T)parameter);
        public void Execute(object parameter) => this.execute((T)parameter);
        public void OnCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
