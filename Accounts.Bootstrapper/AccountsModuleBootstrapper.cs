using Accounts.Adapter.Controllers;
using Accounts.Application.DomainObjectServices;
using Accounts.Contracts;
using Accounts.Domain.DomainObjects;
using Accounts.Infrastructure.Repository;
using Accounts.WebUI.Components.SearchList;
using BusinessAppFramework.Adapter.Interfaces;
using BusinessAppFramework.Application.Descriptors;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Relations;
using BusinessAppFramework.Application.Repository;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Domain;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using Search.Contracts.SearchResults;
using BusinessAppFramework.WebUI.Components.Browser;
using BusinessAppFramework.WebUI.Components.Selector;
using BusinessAppFramework.WebUI.Interfaces;

namespace Accounts.Bootstrapper
{
    public class AccountsModuleBootstrapper : IModuleBootstrapper, IWebApiModuleBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IDomainObjectService<>), typeof(DomainObjectService<>));

            services.AddScoped<IDomainObjectService<BusinessPartner>, BusinessPartnerService>();

            services.AddScoped<IRepository<BusinessPartner>, BusinessPartnerRepository>();
            services.AddScoped<IRepository<BusinessPartnerType>, BusinessPartnerTypeRepository>();
            services.AddScoped<IRepository<Contact>, ContactRepository>();
        }

        public void RegisterControllers(IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddApplicationPart(typeof(BusinessPartnerController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(BusinessPartnerTypeController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(ContactController).Assembly);
        }

        public StringKey? GetModuleWorkspaceKey()
        {
            return StringKey.From(AccountsContracts.AccountsModule);
        }

        public List<StringKey> GetWorkspacesKeys()
        {
            return new List<StringKey>()
         {
            StringKey.From(AccountsContracts.BusinessPartnerWorkspace),
            StringKey.From(AccountsContracts.BusinessPartnerTypeWorkspace),
            StringKey.From(AccountsContracts.ContactsWorkspace)
         };
        }

        public void RegisterLocalizedStrings(IServiceProvider serviceProvider)
        {
            var localizedStringService = serviceProvider.GetRequiredService<ILocalizedStringService>();

            localizedStringService.Add(AccountsContracts.AccountsModule, "fr", "Comptes et contacts");
            localizedStringService.Add(AccountsContracts.BusinessPartnerTypeWorkspace, "fr", "Types de partenaires");
            localizedStringService.Add(AccountsContracts.BusinessPartnerWorkspace, "fr", "Partenaires");
            localizedStringService.Add(AccountsContracts.ContactsWorkspace, "fr", "Contacts");

            localizedStringService.Add(AccountsContracts.BusinessPartnerSelector, "fr", "Sélection de partenaire");
            localizedStringService.Add(AccountsContracts.BusinessPartnerTypeSelector, "fr", "Sélection de type de partenaire");
            localizedStringService.Add(AccountsContracts.ContactSelector, "fr", "Sélection de contact");

            localizedStringService.Add(AccountsContracts.BusinessPartner_Name, "fr", "Nom");
            localizedStringService.Add(AccountsContracts.BusinessPartner_VatNumber, "fr", "TVA");
            localizedStringService.Add(AccountsContracts.BusinessPartner_BusinessPartnerTypeName, "fr", "Type");
            localizedStringService.Add(AccountsContracts.BusinessPartner_ClientNumber, "fr", "Numéro de client");
            localizedStringService.Add(AccountsContracts.BusinessPartner_ProviderNumber, "fr", "Numéro de fournisseur");
            localizedStringService.Add(AccountsContracts.BusinessPartner_BusinessPartnerTypesReferences, "fr", "Types");

            localizedStringService.Add(AccountsContracts.BusinessPartnerType_Name, "fr", "Libellé");

            localizedStringService.Add(AccountsContracts.Contact_Name, "fr", "Nom");
            localizedStringService.Add(AccountsContracts.Contact_ParentName, "fr", "Partenaire");
            localizedStringService.Add(AccountsContracts.Contact_IsActive, "fr", "Actif");
            localizedStringService.Add(AccountsContracts.Contact_Mail, "fr", "Mail");
            localizedStringService.Add(AccountsContracts.Contact_Phone, "fr", "Téléphone");
            localizedStringService.Add(AccountsContracts.Contact_BusinessPartnerReference, "fr", "Partenaire");
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
                StringKey.From(AccountsContracts.BusinessPartnerWorkspace), 
                () => new DomainObjectBrowserDescriptor<BusinessPartner, BusinessPartnerSearchResult>(domainObjectPageWorkspaceKeyResolver, routeKeyRegistry)
                {
                    ComponentType = typeof(DomainObjectBrowser<BusinessPartner, BusinessPartnerSearchResult>),
                    WorkspaceKey = StringKey.From(AccountsContracts.BusinessPartnerWorkspace),
                    SearchListTemplateProviderType = typeof(BusinessPartnerSearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(AccountsContracts.BusinessPartnerTypeWorkspace), 
                () => new DomainObjectBrowserDescriptor<BusinessPartnerType, BusinessPartnerTypeSearchResult>(domainObjectPageWorkspaceKeyResolver, routeKeyRegistry)
                {
                    ComponentType = typeof(DomainObjectBrowser<BusinessPartnerType, BusinessPartnerTypeSearchResult>),
                    WorkspaceKey = StringKey.From(AccountsContracts.BusinessPartnerTypeWorkspace),
                    SearchListTemplateProviderType = typeof(BusinessPartnerTypeSearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(AccountsContracts.ContactsWorkspace), 
                () => new DomainObjectBrowserDescriptor<Contact, ContactSearchResult>(domainObjectPageWorkspaceKeyResolver, routeKeyRegistry)
                {
                    ComponentType = typeof(DomainObjectBrowser<Contact, ContactSearchResult>),
                    WorkspaceKey = StringKey.From(AccountsContracts.ContactsWorkspace),
                    SearchListTemplateProviderType = typeof(ContactSearchListTemplateProvider)
                });
        }

        public void RegisterSelectorDescriptors(IServiceProvider serviceProvider)
        {
            var workspaceDescriptorFactory = serviceProvider.GetRequiredService<IWorkspaceDescriptorFactory>();

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(AccountsContracts.BusinessPartnerSelector), () => new DomainObjectSelectorDescriptor<BusinessPartner, BusinessPartnerSearchResult>
                {
                    ComponentType = typeof(DomainObjectSelector<BusinessPartner, BusinessPartnerSearchResult>),
                    WorkspaceKey = StringKey.From(AccountsContracts.BusinessPartnerSelector),
                    SearchListTemplateProviderType = typeof(BusinessPartnerSearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(AccountsContracts.BusinessPartnerTypeSelector), () => new DomainObjectSelectorDescriptor<BusinessPartnerType, BusinessPartnerTypeSearchResult>
                {
                    ComponentType = typeof(DomainObjectSelector<BusinessPartnerType, BusinessPartnerTypeSearchResult>),
                    WorkspaceKey = StringKey.From(AccountsContracts.BusinessPartnerTypeSelector),
                    SearchListTemplateProviderType = typeof(BusinessPartnerTypeSearchListTemplateProvider)
                });

            workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
                StringKey.From(AccountsContracts.ContactSelector), () => new DomainObjectSelectorDescriptor<Contact, ContactSearchResult>
                {
                    ComponentType = typeof(DomainObjectSelector<Contact, ContactSearchResult>),
                    WorkspaceKey = StringKey.From(AccountsContracts.ContactSelector),
                    SearchListTemplateProviderType = typeof(ContactSearchListTemplateProvider)
                });
        }

        public void RegisterReferenceSelectors(IServiceProvider serviceProvider)
        {
            var relationSelectorRegistry = serviceProvider.GetRequiredService<IRelationSelectorRegistry>();

            relationSelectorRegistry.Register(StringKey.From(AccountsContracts.BusinessPartnerBusinessPartnerTypeReference), StringKey.From(AccountsContracts.BusinessPartnerTypeSelector));
            relationSelectorRegistry.Register(StringKey.From(AccountsContracts.ContactBusinessPartnerReference), StringKey.From(AccountsContracts.BusinessPartnerSelector));
        }

        public void RegisterDomainObjectBrowserWorkspaces(IServiceProvider serviceProvider)
        {
            var domainObjectBrowserWorkspaceRegistry = serviceProvider.GetRequiredService<IDomainObjectBrowserWorkspaceRegistry>();

            domainObjectBrowserWorkspaceRegistry.Register<BusinessPartner>(StringKey.From(AccountsContracts.BusinessPartnerWorkspace));
            domainObjectBrowserWorkspaceRegistry.Register<BusinessPartnerType>(StringKey.From(AccountsContracts.BusinessPartnerTypeWorkspace));
            domainObjectBrowserWorkspaceRegistry.Register<Contact>(StringKey.From(AccountsContracts.ContactsWorkspace));
        }

        public void RegisterIcons(IServiceProvider serviceProvider)
        {
            var iconFactory = serviceProvider.GetRequiredService<IIconFactory>();

            iconFactory.RegisterIcon(StringKey.From(AccountsContracts.AccountsModule), Icons.Material.Outlined.AccountCircle);

            iconFactory.RegisterIcon(StringKey.From(AccountsContracts.BusinessPartnerWorkspace), Icons.Material.Outlined.Handshake);
            iconFactory.RegisterIcon(StringKey.From(AccountsContracts.BusinessPartnerTypeWorkspace), Icons.Material.Outlined.Category);
            iconFactory.RegisterIcon(StringKey.From(AccountsContracts.ContactsWorkspace), Icons.Material.Outlined.Contacts);
        }

        public void RegisterDomainObjectTypesMapping(IServiceProvider serviceProvider)
        {
            var domainObjectTypeMap = serviceProvider.GetRequiredService<IDomainObjectTypeMap>();

            domainObjectTypeMap.Register(typeof(BusinessPartner), typeof(Infrastructure.Entities.BusinessPartner), typeof(BusinessPartnerSearchResult));
            domainObjectTypeMap.Register(typeof(BusinessPartnerType), typeof(Infrastructure.Entities.BusinessPartnerType), typeof(BusinessPartnerTypeSearchResult));
            domainObjectTypeMap.Register(typeof(Contact), typeof(Infrastructure.Entities.Contact), typeof(ContactSearchResult));
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

            routeKeyRegistry.RegisterRouteKey<BusinessPartner>(Accounts.Contracts.RouteKeys.BusinessPartner);
            routeKeyRegistry.RegisterRouteKey<BusinessPartnerType>(Accounts.Contracts.RouteKeys.BusinessPartnerType);
            routeKeyRegistry.RegisterRouteKey<Contact>(Accounts.Contracts.RouteKeys.Contact);            
        }
    }
}
