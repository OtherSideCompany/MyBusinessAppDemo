using BaseData.Application.Services;
using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Adapter.Interfaces;
using BusinessAppFramework.Application.AppConfiguration;
using BusinessAppFramework.Application.DomainObjectEvents;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Mail;
using BusinessAppFramework.Application.Registry;
using BusinessAppFramework.Application.Relations;
using BusinessAppFramework.Application.Repository;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Application.Trees;
using BusinessAppFramework.Bootstrapper.Services;
using BusinessAppFramework.DocumentRendering;
using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Services;
using BusinessAppFramework.Infrastructure.DocumentStorage;
using BusinessAppFramework.Infrastructure.Factories;
using BusinessAppFramework.Infrastructure.FileSerialization;
using BusinessAppFramework.Infrastructure.ImageCompression;
using BusinessAppFramework.Infrastructure.Logger;
using BusinessAppFramework.Infrastructure.Mail;
using BusinessAppFramework.Infrastructure.Mapping;
using BusinessAppFramework.Infrastructure.Password;
using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBusinessApp.Application;
using MyBusinessApp.Application.AppConfiguration;
using MyBusinessApp.Application.Services;
using MyBusinessApp.Contracts;
using MyBusinessApp.Documents;
using MyBusinessApp.Infrastructure.Entities;
using MyBusinessApp.Infrastructure.Factories;
using MyBusinessApp.Infrastructure.Mapping;
using MyBusinessApp.Infrastructure.Services;

namespace MyBusinessApp.Bootstrapper.Services
{
   public class BootstrapService : IBootstrapService
   {
      #region Fields


      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BootstrapService()
      {

      }

      #endregion

      #region Public Methods

      public IServiceCollection GetServices(ConfigurationManager configurationManager)
      {
         var serviceCollection = new ServiceCollection();

         GetGlobalServices(serviceCollection, configurationManager);
         GetModulesServices(serviceCollection);
         GetGenericTypeServices(serviceCollection);

         return serviceCollection;
      }

      #endregion

      #region Private Methods

      private void GetGlobalServices(ServiceCollection services, ConfigurationManager configurationManager)
      {
         var localAppDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
         var appFolderPath = Path.Combine(localAppDataFolderPath, AppInfo.Name);
         var logFile = Path.Combine(appFolderPath, "logs.txt");

         Directory.CreateDirectory(appFolderPath);

         if (File.Exists(logFile))
         {
            File.Delete(logFile);
         }

         services.AddLogging(builder =>
         {
            Logger.ConfigureLogger(builder, logFile);
         });

         services.AddAutoMapper(cfg =>
         {
            cfg.AddProfile<InfrastructureMappingProfile>();
            //cfg.AddProfile<ManufacturingAdapterMappingProfile>();
         });

         services.AddSingleton<IUserPermissionResolverService, UserPermissionResolverService>();

         services.AddSingleton<IModuleBootstrapperProviderService, ModuleBootstrapperProviderService>();
         services.AddSingleton<IAppConfiguration, MyBusinessAppConfiguration>();
         services.AddSingleton<IFileSerializationService, JsonFileSerializationService>();

         services.AddSingleton<IImageCompressionService, ImageCompressionService>();

         services.AddSingleton<IMailService, MailtoMailService>();
         services.AddSingleton<ICalendarService, CalendarService>();
         services.AddSingleton<IRelationResolver, MyBusinessAppRelationResolver>();
         services.AddScoped<IRelationService, RelationService>();

         services.AddScoped<IUserContext, UserContext>();
         services.AddHttpContextAccessor();
         services.AddSingleton<IDbContextFactory<DbContext>, DbContextFactory>();
         services.AddSingleton<IDbInitializerService, MyBusinessAppWebDbInitializerService>();
         services.AddSingleton<IPasswordService, PasswordService>();
         services.AddScoped<IAuthenticationTokenService, JwtAuthenticationTokenService>();
         services.AddSingleton<IGlobalDataService, GlobalDataService>();
         services.AddSingleton<IDomainObjectEventBus, DomainObjectEventBus>();
         services.AddSingleton<IDomainObjectTypeMap, DomainObjectTypeMap>();
         services.AddScoped<ICurrentUserService, CurrentUserService>();
         services.AddSingleton<ILocalizedStringService, LocalizedStringService>();
         services.AddSingleton<IConstraintFactory, ConstraintFactory>();
         services.AddScoped<IReferenceHydrator, ReferenceHydrator>();
         services.AddSingleton<IWorkflowFactory, WorkflowFactory>();
         services.AddSingleton<IWorkflowService, WorkflowService>();
         services.AddSingleton<IWorkflowContextLoaderFactory, WorkflowContextLoaderFactory>();
         services.AddSingleton<IDomainObjectRouteKeyRegistry, DomainObjectRouteKeyRegistry>();
         services.AddHttpContextAccessor();

         services.AddScoped<IRepositoryFactory, RepositoryFactory>();
         services.AddScoped<ISearchServiceFactory, SearchServiceFactory>();
         services.AddScoped<IDomainObjectServiceFactory, DomainObjectServiceFactory>();
         services.AddScoped<IDomainObjectDocumentServiceFactory, DomainObjectDocumentServiceFactory>();
         services.AddSingleton<ITreeFactory, TreeFactory>();

         var rootPath = configurationManager["DocumentStorage:RootPath"] ?? throw new InvalidOperationException("DocumentStorage:RootPath is missing.");
         services.AddScoped<IDocumentStorageService>(_ => new FileSystemDocumentStorageService(rootPath));

         services.AddScoped<IDocumentGenerator, DocumentGenerator>();
         services.AddScoped<IHtmlDocumentRenderer, HtmlDocumentRenderer>();
         services.AddSingleton<IHtmlDocumentTemplateRegistry, HtmlDocumentTemplateRegistry>();
         services.AddScoped<IDocumentModelLoaderFactory, DocumentModelLoaderFactory>();
         services.AddSingleton<IDocumentModelLoaderTypeRegistry, DocumentModelLoaderTypeRegistry>();

         services.AddTransient<RepositoryDependencies>();
         services.AddTransient<DomainObjectServiceDependencies>();
      }

      private void GetModulesServices(ServiceCollection services)
      {
         var moduleProviderService = new ModuleBootstrapperProviderService();

         var modules = moduleProviderService.GetModules();

         foreach (var module in modules)
         {
            module.RegisterServices(services);
         }

         var searchModules = moduleProviderService.GetSearchModules();

         foreach (var searchModule in searchModules)
         {
            searchModule.RegisterServices(services);
         }
      }

      private void GetGenericTypeServices(ServiceCollection services)
      {
         services.AddTransient(typeof(ISearchService<>), typeof(SearchService<>));
         services.AddTransient(typeof(IDomainObjectService<>), typeof(DomainObjectService<>));
         services.AddTransient(typeof(IDomainObjectDocumentService<>), typeof(DomainObjectDocumentService<>));
      }

      public void RegisterControllers(IMvcBuilder mvcBuilder)
      {
         mvcBuilder.AddApplicationPart(typeof(NavigationController).Assembly);
         mvcBuilder.AddApplicationPart(typeof(RelationServiceController).Assembly);
         mvcBuilder.AddApplicationPart(typeof(TreeController).Assembly);
         mvcBuilder.AddApplicationPart(typeof(WorkflowController).Assembly);

         var moduleProviderService = new ModuleBootstrapperProviderService();

         var modules = moduleProviderService.GetModules();

         foreach (var module in modules.OfType<IWebApiModuleBootstrapper>())
         {
            module.RegisterControllers(mvcBuilder);
         }

         var searchModules = moduleProviderService.GetSearchModules();

         foreach (var searchModule in searchModules.OfType<IWebApiModuleBootstrapper>())
         {
            searchModule.RegisterControllers(mvcBuilder);
         }
      }

      public void RegisterModules(IServiceProvider serviceProvider)
      {
         var moduleProviderService = new ModuleBootstrapperProviderService();

         var modules = moduleProviderService.GetModules();

         foreach (var module in modules.OfType<IModuleBootstrapper>())
         {
            module.RegisterConstraints(serviceProvider);
            module.RegisterDomainObjectTypesMapping(serviceProvider);
            module.RegisterWorkflows(serviceProvider);
            module.RegisterWorkflowContextLoader(serviceProvider);
            module.RegisterDomainObjectRouteKeys(serviceProvider);
            module.RegisterDomainObjectRouteKeys(serviceProvider);
         }
      }

      public void RegisterTrees(IServiceProvider serviceProvider)
      {
         var treeFactory = serviceProvider.GetService<ITreeFactory>();

         treeFactory?.RegisterTree(StringKey.From(MyBusinessAppContracts.BusinessPartnerPageTree), () =>
         {
            var tree = new Tree();
            tree.Branches.Add(new Branch(ParentChildRelationKeys.BusinessPartnerAdressRelationKey));
            tree.Branches.Add(new Branch(ParentChildRelationKeys.BusinessPartnerContactRelationKey));
            tree.Branches.Add(new Branch(ParentChildRelationKeys.BusinessPartnerNoteRelationKey));
            return tree;
         });

         treeFactory?.RegisterTree(StringKey.From(MyBusinessAppContracts.CompanyPageTree), () =>
         {
            var tree = new Tree();
            tree.Branches.Add(new Branch(ParentChildRelationKeys.CompanyAdressRelationKey));
            return tree;
         });
      }

      public void RegisterLocalizedStrings(IServiceProvider serviceProvider)
      {
         var localizedStringService = serviceProvider.GetService<ILocalizedStringService>()!;
      }

      public void RegisterDocuments(IServiceProvider serviceProvider)
      {
         var htmlDocumentRegistry = serviceProvider.GetService<IHtmlDocumentTemplateRegistry>();
         var documentModelLoaderTypeRegistry = serviceProvider.GetService<IDocumentModelLoaderTypeRegistry>();

         var externalDocumentResourceName = "ExternalDocumentTemplate.html";
      }

      #endregion
   }
}
