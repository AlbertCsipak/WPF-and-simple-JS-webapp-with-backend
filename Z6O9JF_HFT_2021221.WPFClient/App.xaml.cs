using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Windows;
using Z6O9JF_HFT_2021221.WPFClient.Logic;
using Z6O9JF_HFT_2021221.WPFClient.Services;

namespace Z6O9JF_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<ICarMenuLogic, CarMenuLogic>()
                .AddSingleton<ICarCreatorService, CarCreatorViaWindow>()
                .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                .BuildServiceProvider()
            );
        }
    }
}
