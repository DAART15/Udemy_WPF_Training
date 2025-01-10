
using System.Windows;

namespace NotebookNotes
{
    public partial class App : Application
    {
        /*public readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }

            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetService<MainWindow>() ?? throw new InvalidOperationException("MainWindow could not be resolved from the service provider.");
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider.Dispose();
            base.OnExit(e);
        }*/
    }

}
