using Prism.Ioc;
using ZZA.Dashboard.Views;
using System.Windows;
using ZZA.Dashboard.Repositories;
using ZZA.Dashboard.Data;

namespace ZZA.Dashboard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ApplicationContext>();
        }
    }
}
