using DeliveryDesktop.MappingProfiles;
using DeliveryDesktop.Services;
using DeliveryDesktop.ViewModels;
using DeliveryDesktop.Services;
using DeliveryDesktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;

namespace DeliveryDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string BaseURL = "https://localhost:56541";

        private IHost? _host;

        protected override void OnStartup(StartupEventArgs args)
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            // Создание главного окна через DI
            var ordersWindow = _host.Services.GetRequiredService<OrdersView>();
            ordersWindow.DataContext = _host.Services.GetRequiredService<OrdersViewModel>();
            ordersWindow.Show();

            base.OnStartup(args);
        }


        private void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(DTOMappringProfile));

            // Register API

            services.AddRefitClient<IOrdersApiService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseURL));

            services.AddRefitClient<ICouriersApiService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseURL));

            services.AddRefitClient<IOrderStatusApiService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(BaseURL));

            // Register Views

            services.AddSingleton<OrdersView>();
            services.AddTransient<CreateOrderView>();
            services.AddTransient<EditOrderView>();
            services.AddTransient<CancelOrderView>();
            services.AddTransient<RegisterCourierView>();

            // Register ViewModels

            services.AddSingleton<OrdersViewModel>();
            services.AddTransient<CreateOrderViewModel>();
            services.AddTransient<EditOrderViewModel>();
            services.AddTransient<CancelOrderViewModel>();
            services.AddTransient<RegisterCourierViewModel>();

            // Services

            services.AddTransient<IDialogService, DialogService>();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            // Dispose of services if needed
            if (_host is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }

}
