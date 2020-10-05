using System;
using System.Windows;
using System.Windows.Input;
using Assignment7.Models;
using NativeMVVMBase;
using Unity;

namespace Assignment7.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _status;
        private IHeavyWorkService _workService;
        public ICommand DoWorkCommand => Commands[nameof(DoWorkCommand)];

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value, Commands[nameof(DoWorkCommand)].InvokeCanExecuteChanged);
        }

        public MainViewModel():base(null) {throw new  NotSupportedException("Default constructor left for DI work around");}
        [InjectionConstructor]
        public MainViewModel(FrameworkElement window,IHeavyWorkService workService) :base(window)
        {
            _workService = workService;
            AddCommand(
                    nameof(DoWorkCommand),
                    _ =>_workService.start3HeavyTasks(newStatus => Status = newStatus),
                    _ => !_workService.isWorking 

                );
        }
    }
}
