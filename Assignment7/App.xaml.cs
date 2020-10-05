using System.Windows;
using Assignment7.Models;
using Assignment7.ViewModels;
using Unity;
using Unity.Injection;

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IHeavyWorkService, HeavyWorkService>();
            container.RegisterType<MainWindow>();
            var mainWindow= container.Resolve<MainWindow>();
            container.RegisterType<MainViewModel>(new InjectionConstructor(new object[]{mainWindow,container.Resolve<IHeavyWorkService>() }));
            container.Resolve<MainViewModel>();
            mainWindow.Show();
        }
    }
}
