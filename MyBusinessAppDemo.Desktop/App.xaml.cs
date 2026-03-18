using Manufacturing.Bootstrap.Services;
using Microsoft.Extensions.DependencyInjection;
using Manufacturing.Adapter;
using Manufacturing.Desktop.Services;
using Manufacturing.Infrastructure.Services;
using OtherSideCore.Adapter.Services;
using OtherSideCore.Appplication.Services;
using OtherSideCore.Infrastructure.Services;
using OtherSideCore.Utils;
using OtherSideCore.Wpf.Services;
using OtherSideCore.Wpf.UserControls.Window;
using System.Windows;
using OtherSideCore.Adapter.DomainObjectInteractionViewModel;
using OtherSideCore.Wpf.Factories;
using Manufacturing.Desktop.Factories;

namespace Manufacturing.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
   {
      private readonly IServiceProvider _serviceProvider;

      public App()
      {
         var manufacturingBootstrapService = new ManufacturingBootstrapService();
         var serviceCollection = manufacturingBootstrapService.GetServices();

         serviceCollection.AddSingleton<IViewLocatorService, ManufacturingViewLocatorService>();
         serviceCollection.AddSingleton<IPropertyEditorFactory, ManufacturingPropertyEditorFactory>();
         serviceCollection.AddSingleton<IWindowService, WindowService>();
         serviceCollection.AddSingleton<IUserDialogService, UserDialogService>();
         serviceCollection.AddSingleton<IDbInitializerService, ManufacturingDbInitializerService>();
         serviceCollection.AddTransient<MainWindow>();
         serviceCollection.AddTransient<SubWindow>();        

         _serviceProvider = serviceCollection.BuildServiceProvider();    
      }

      protected override async void OnStartup(StartupEventArgs e)
      {
         ApplicationCultureInfo.OverrideCurrentCultureInfo("fr-FR");
         base.OnStartup(e);

         var dbInitializerService = _serviceProvider.GetRequiredService<IDbInitializerService>();
         await dbInitializerService.InitializeDatabaseAsync();
        
         var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
         var mainWindowViewModel = _serviceProvider.GetRequiredService<ManufacturingMainWindowViewModel>();
         mainWindow.DataContext = mainWindowViewModel;

         var windowService = _serviceProvider.GetRequiredService<IWindowService>();
         windowService.ConfigureMainWindow(mainWindow);
         windowService.ConfigureService(typeof(ManufacturingSubWindowViewModel));

         mainWindow.Show();
      }
   }
}

