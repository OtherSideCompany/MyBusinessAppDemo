using BaseData.Adapter.Controllers;
using BaseData.Application.DomainObjectServices;
using BaseData.Contracts;
using BaseData.Domain.DomainObjects;
using BaseData.Infrastructure.Repositories;
using BaseData.WebUI.Components.SearchList;
using BusinessAppFramework.Adapter.Interfaces;
using BusinessAppFramework.Application.Descriptors;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Relations;
using BusinessAppFramework.Application.Repository;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Domain;
using BusinessAppFramework.WebUI.Components.Browser;
using BusinessAppFramework.WebUI.Components.Selector;
using BusinessAppFramework.WebUI.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using Search.Contracts.SearchResults;

namespace BaseData.Bootstrapper
{
    public class BaseDataModuleBootstrapper : IModuleBootstrapper, IWebApiModuleBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {            
            services.AddScoped(typeof(IDomainObjectService<>), typeof(DomainObjectService<>));

            services.AddScoped<IDomainObjectService<Company>, CompanyService>();

            services.AddScoped<IRepository<Adress>, AdressRepository>();
            services.AddScoped<IRepository<Company>, CompanyRepository>();
            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<IRepository<Document>, DocumentRepository>();
            services.AddScoped<IRepository<Note>, NoteRepository>();
            services.AddScoped<IRepository<PostalCode>, PostalCodeRepository>();
        }

        public void RegisterControllers(IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddApplicationPart(typeof(AdressController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(CompanyController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(CountryController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(DocumentController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(NoteController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(PostalCodeController).Assembly);
        }

        public StringKey? GetModuleWorkspaceKey()
        {
            return StringKey.From(BaseDataContracts.BaseDataModule);
        }

        public List<StringKey> GetWorkspacesKeys()
        {
            return new List<StringKey>()
             {
                StringKey.From(BaseDataContracts.CompanyBrowserWorkspace),
                StringKey.From(BaseDataContracts.CountryBrowserWorkspace),
                StringKey.From(BaseDataContracts.DocumentBrowserWorkspace),
                StringKey.From(BaseDataContracts.PostalCodeBrowserWorkspace)
             };
        }

        public void RegisterLocalizedStrings(IServiceProvider serviceProvider)
        {
            var localizedStringService = serviceProvider.GetRequiredService<ILocalizedStringService>();

            localizedStringService.Add(BaseDataContracts.BaseDataModule, "fr", "Données");
            localizedStringService.Add(BaseDataContracts.CompanyBrowserWorkspace, "fr", "Entreprise");
            localizedStringService.Add(BaseDataContracts.CountryBrowserWorkspace, "fr", "Pays");
            localizedStringService.Add(BaseDataContracts.DocumentBrowserWorkspace, "fr", "Documents");
            localizedStringService.Add(BaseDataContracts.PostalCodeBrowserWorkspace, "fr", "Codes postaux");

            localizedStringService.Add(BaseDataContracts.AdressSelector, "fr", "Sélection d'adresse");
            localizedStringService.Add(BaseDataContracts.CountrySelector, "fr", "Sélection de pays");
            localizedStringService.Add(BaseDataContracts.PostalCodeSelector, "fr", "Sélection de code postal");
            localizedStringService.Add(BaseDataContracts.TeamMemberSelector, "fr", "Sélection de membre de l'équipe");

            localizedStringService.Add(BaseDataContracts.Adress_Label, "fr", "Libellé");
            localizedStringService.Add(BaseDataContracts.Adress_AdressDescription, "fr", "Adresse");
            localizedStringService.Add(BaseDataContracts.Adress_PostalCodeReference, "fr", "Code postal");

            localizedStringService.Add(BaseDataContracts.Company_Name, "fr", "Libellé");
            localizedStringService.Add(BaseDataContracts.Company_VatNumber, "fr", "TVA");
            localizedStringService.Add(BaseDataContracts.Company_WebsiteUrl, "fr", "Site web");
            localizedStringService.Add(BaseDataContracts.Company_Phone, "fr", "Téléphone");

            localizedStringService.Add(BaseDataContracts.Country_Name, "fr", "Libellé");
            localizedStringService.Add(BaseDataContracts.Country_Alpha2Code, "fr", "Code alpha 2");
            localizedStringService.Add(BaseDataContracts.Country_Alpha3Code, "fr", "Code alpha 3");
            localizedStringService.Add(BaseDataContracts.Country_NumericCode, "fr", "Code numérique");

            localizedStringService.Add(BaseDataContracts.Document_FileName, "fr", "Nom de fichier");
            localizedStringService.Add(BaseDataContracts.Document_ContentType, "fr", "Type");
            localizedStringService.Add(BaseDataContracts.Document_Size, "fr", "Taille");
            localizedStringService.Add(BaseDataContracts.Document_CreatedByName, "fr", "Créé par");

            localizedStringService.Add(BaseDataContracts.Note_Text, "fr", "Note");

            localizedStringService.Add(BaseDataContracts.PostalCode_Code, "fr", "Code postal");
            localizedStringService.Add(BaseDataContracts.PostalCode_City, "fr", "Localité");
            localizedStringService.Add(BaseDataContracts.PostalCode_CountryReference, "fr", "Pays");
        }

        public void RegisterConstraints(IServiceProvider serviceProvider)
        {
            var constraintFactory = serviceProvider.GetRequiredService<IConstraintFactory>();
        }

        public void RegisterBrowserDescriptors(IServiceProvider serviceProvider)
        {
            var workspaceDescriptorFactory = serviceProvider.GetRequiredService<IWorkspaceDescriptorFactory>();
            var domainObjectPageWorkspaceKeyResolver = serviceProvider.GetRequiredService<IDomainObjectPageWorkspaceKeyRegistry>();
            var routeKeyRegistry = serviceProvider.GetRequiredService<IDomainObjectRouteKeyRegistry>();

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(BaseDataContracts.CompanyBrowserWorkspace), () => new DomainObjectBrowserDescriptor<Company, CompanySearchResult>(domainObjectPageWorkspaceKeyResolver, routeKeyRegistry)
                {
                    ComponentType = typeof(DomainObjectBrowser<Company, CompanySearchResult>),
                    WorkspaceKey = StringKey.From(BaseDataContracts.CompanyBrowserWorkspace),
                    SearchListTemplateProviderType = typeof(CompanySearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(BaseDataContracts.CountryBrowserWorkspace), () => new DomainObjectBrowserDescriptor<Country, CountrySearchResult>(domainObjectPageWorkspaceKeyResolver, routeKeyRegistry)
                {
                    ComponentType = typeof(DomainObjectBrowser<Country, CountrySearchResult>),
                    WorkspaceKey = StringKey.From(BaseDataContracts.CountryBrowserWorkspace),
                    SearchListTemplateProviderType = typeof(CountrySearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(BaseDataContracts.DocumentBrowserWorkspace), () => new DomainObjectBrowserDescriptor<Document, DocumentSearchResult>(domainObjectPageWorkspaceKeyResolver, routeKeyRegistry)
                {
                    ComponentType = typeof(DomainObjectBrowser<Document, DocumentSearchResult>),
                    WorkspaceKey = StringKey.From(BaseDataContracts.DocumentBrowserWorkspace),
                    SearchListTemplateProviderType = typeof(DocumentSearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(BaseDataContracts.PostalCodeBrowserWorkspace), () => new DomainObjectBrowserDescriptor<PostalCode, PostalCodeSearchResult>(domainObjectPageWorkspaceKeyResolver, routeKeyRegistry)
                {
                    ComponentType = typeof(DomainObjectBrowser<PostalCode, PostalCodeSearchResult>),
                    WorkspaceKey = StringKey.From(BaseDataContracts.PostalCodeBrowserWorkspace),
                    SearchListTemplateProviderType = typeof(PostalCodeSearchListTemplateProvider)
                });            
        }

        public void RegisterSelectorDescriptors(IServiceProvider serviceProvider)
        {
            var workspaceDescriptorFactory = serviceProvider.GetRequiredService<IWorkspaceDescriptorFactory>();

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(BaseDataContracts.AdressSelector), () => new DomainObjectSelectorDescriptor<Adress, AdressSearchResult>
                {
                    ComponentType = typeof(DomainObjectSelector<Adress, AdressSearchResult>),
                    WorkspaceKey = StringKey.From(BaseDataContracts.AdressSelector),
                    SearchListTemplateProviderType = typeof(AdressSearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(BaseDataContracts.CountrySelector), () => new DomainObjectSelectorDescriptor<Country, CountrySearchResult>
                {
                    ComponentType = typeof(DomainObjectSelector<Country, CountrySearchResult>),
                    WorkspaceKey = StringKey.From(BaseDataContracts.CountrySelector),
                    SearchListTemplateProviderType = typeof(CountrySearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(BaseDataContracts.PostalCodeSelector), () => new DomainObjectSelectorDescriptor<PostalCode, PostalCodeSearchResult>
                {
                    ComponentType = typeof(DomainObjectSelector<PostalCode, PostalCodeSearchResult>),
                    WorkspaceKey = StringKey.From(BaseDataContracts.PostalCodeSelector),
                    SearchListTemplateProviderType = typeof(PostalCodeSearchListTemplateProvider)
                });            
        }

        public void RegisterReferenceSelectors(IServiceProvider serviceProvider)
        {
            var relationSelectorRegistry = serviceProvider.GetRequiredService<IRelationSelectorRegistry>();

            relationSelectorRegistry.Register(StringKey.From(BaseDataContracts.PostalCodeCountryReference), StringKey.From(BaseDataContracts.CountrySelector));
            relationSelectorRegistry.Register(StringKey.From(BaseDataContracts.AdressPostalCodeReference), StringKey.From(BaseDataContracts.PostalCodeSelector));
        }

        public void RegisterDomainObjectBrowserWorkspaces(IServiceProvider serviceProvider)
        {
            var domainObjectBrowserWorkspaceRegistry = serviceProvider.GetRequiredService<IDomainObjectBrowserWorkspaceRegistry>();

            domainObjectBrowserWorkspaceRegistry.Register<Company>(StringKey.From(BaseDataContracts.CompanyBrowserWorkspace));
            domainObjectBrowserWorkspaceRegistry.Register<Country>(StringKey.From(BaseDataContracts.CountryBrowserWorkspace));
            domainObjectBrowserWorkspaceRegistry.Register<Document>(StringKey.From(BaseDataContracts.DocumentBrowserWorkspace));
            domainObjectBrowserWorkspaceRegistry.Register<PostalCode>(StringKey.From(BaseDataContracts.PostalCodeBrowserWorkspace));
        }

        public void RegisterIcons(IServiceProvider serviceProvider)
        {
            var iconFactory = serviceProvider.GetRequiredService<IIconFactory>();

            iconFactory.RegisterIcon(StringKey.From(BaseDataContracts.BaseDataModule), Icons.Material.Outlined.Dataset);

            iconFactory.RegisterIcon(StringKey.From(BaseDataContracts.CompanyBrowserWorkspace), Icons.Material.Outlined.Business);
            iconFactory.RegisterIcon(StringKey.From(BaseDataContracts.CountryBrowserWorkspace), Icons.Material.Outlined.Public);
            iconFactory.RegisterIcon(StringKey.From(BaseDataContracts.DocumentBrowserWorkspace), Icons.Material.Outlined.InsertDriveFile);
            iconFactory.RegisterIcon(StringKey.From(BaseDataContracts.PostalCodeBrowserWorkspace), Icons.Material.Outlined.LocationOn);
        }

        public void RegisterDomainObjectTypesMapping(IServiceProvider serviceProvider)
        {
            var domainObjectTypeMap = serviceProvider.GetRequiredService<IDomainObjectTypeMap>();

            domainObjectTypeMap.Register(typeof(Adress), typeof(Infrastructure.Entities.Adress), typeof(AdressSearchResult));
            domainObjectTypeMap.Register(typeof(Company), typeof(Infrastructure.Entities.Company), typeof(CompanySearchResult));
            domainObjectTypeMap.Register(typeof(Country), typeof(Infrastructure.Entities.Country), typeof(CountrySearchResult));
            domainObjectTypeMap.Register(typeof(Document), typeof(Infrastructure.Entities.Document), typeof(DocumentSearchResult));
            domainObjectTypeMap.Register(typeof(Note), typeof(Infrastructure.Entities.Note), typeof(NoteSearchResult));
            domainObjectTypeMap.Register(typeof(PostalCode), typeof(Infrastructure.Entities.PostalCode), typeof(PostalCodeSearchResult));
        }

        public void RegisterWorkflows(IServiceProvider serviceProvider)
        {

        }

        public void RegisterWorkflowContextLoader(IServiceProvider serviceProvider)
        {

        }

        public void RegisterDomainObjectRouteKeys(IServiceProvider serviceProvider)
        {
            var routeKeyRegistry = serviceProvider.GetRequiredService<IDomainObjectRouteKeyRegistry>();

            routeKeyRegistry.RegisterRouteKey<Adress>(BaseData.Contracts.RouteKeys.Address);
            routeKeyRegistry.RegisterRouteKey<Company>(BaseData.Contracts.RouteKeys.Company);
            routeKeyRegistry.RegisterRouteKey<Country>(BaseData.Contracts.RouteKeys.Country);
            routeKeyRegistry.RegisterRouteKey<Document>(BaseData.Contracts.RouteKeys.Document);
            routeKeyRegistry.RegisterRouteKey<Note>(BaseData.Contracts.RouteKeys.Note);
        }
    }
}
