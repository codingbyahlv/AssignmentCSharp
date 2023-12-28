using Assignment.Shared.Interfaces;
using Assignment.Shared.Respository;
using Assignment.WpfApp.Interfaces;
using Assignment.WpfApp.Services;
using Assignment.WpfApp.ViewModels;
using Assignment.WpfApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Assignment.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices (services =>
                {
                    services.AddSingleton<IContactService, ContactService>();
                    services.AddSingleton<ContactRepository>();
                    services.AddSingleton<IContactRepository>(provider => provider.GetRequiredService<ContactRepository>());
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();

                    services.AddTransient<ContactAddViewModel>();
                    services.AddTransient<ContactAddView>();
                    services.AddTransient<ContactDetailsViewModel>();
                    services.AddTransient<ContactDetailsView>();
                    services.AddTransient<ContactListViewModel>();
                    services.AddTransient<ContactListView>();
                    services.AddTransient<ContactUpdateViewModel>();
                    services.AddTransient<ContactUpdateView>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host!.Start();
            MainWindow mainWindow = _host!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
