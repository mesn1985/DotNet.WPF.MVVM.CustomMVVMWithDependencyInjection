using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NativeMVVMBase
{
    /// <summary>
    /// POC - not for production
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler      PropertyChanged;
        protected Dictionary<string, DelegateCommand> Commands = new Dictionary<string, DelegateCommand>();
        public ViewModelBase(FrameworkElement window)
        {
            window.DataContext = this;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T field, T newValue, Action sideEffect, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        protected void AddCommand(string name, Action<object> execute, Func<object, bool> canExecute)
        {
            Commands[name] = new DelegateCommand(execute, canExecute);
        }
    }
}
