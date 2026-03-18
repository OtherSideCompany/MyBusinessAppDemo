using Accounts.Domain.DomainObjects;
using BaseData.Domain.DomainObjects;
using BaseData.WebUI.Interfaces;
using BaseData.WebUI.Services;
using BusinessAppFramework.Application.Descriptors;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Registry;
using BusinessAppFramework.Application.Relations;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.DomainObjects;
using BusinessAppFramework.Infrastructure.ImageCompression;
using BusinessAppFramework.Infrastructure.Mapping;
using BusinessAppFramework.WebUI.Components.Pages.DomainObjectPages;
using BusinessAppFramework.WebUI.Factories;
using BusinessAppFramework.WebUI.Interfaces;
using BusinessAppFramework.WebUI.Services;
using MudBlazor;
using MudBlazor.Services;
using MyBusinessApp.Bootstrapper.Services;
using MyBusinessApp.Contracts;
using MyBusinessApp.Infrastructure.Entities;
using MyBusinessAppDemo.WebUI.Components;
using MyBusinessAppDemo.WebUI.Components.DomainObjectPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddSingleton<IModuleBootstrapperProviderService, ModuleBootstrapperProviderService>();
builder.Services.AddSingleton<ILocalizedStringService, LocalizedStringService>();
builder.Services.AddScoped<IWorkspaceNavigationService, WorkspaceNavigationService>();
builder.Services.AddSingleton<IWorkspaceDescriptorFactory, WorkspaceDescriptorFactory>();
builder.Services.AddScoped<IApplicationActionExecutionService, ApplicationActionExecutionService>();
builder.Services.AddScoped(typeof(ISearchGateway<>), typeof(DomainObjectSearchGateway<>));
builder.Services.AddScoped(typeof(IDomainObjectServiceGateway<>), typeof(DomainObjectServiceGateway<>));
builder.Services.AddScoped(typeof(IDomainObjectDocumentServiceGateway<>), typeof(DomainObjectDocumentServiceGateway<>));
builder.Services.AddScoped(typeof(ICompanyServiceGateway), typeof(CompanyServiceGateway));
builder.Services.AddSingleton<IIconFactory, IconFactory>();
builder.Services.AddScoped<IUserDialogService, UserDialogService>();
builder.Services.AddSingleton<IRelationResolver, MyBusinessAppRelationResolver>();
builder.Services.AddSingleton<IRelationSelectorRegistry, RelationSelectorRegistry>();
builder.Services.AddSingleton<IDomainObjectBrowserWorkspaceRegistry, DomainObjectBrowserWorkspaceRegistry>();
builder.Services.AddSingleton<IDomainObjectPageWorkspaceKeyRegistry, DomainObjectPageWorkspaceKeyRegistry>();
builder.Services.AddScoped<IRelationServiceGateway, RelationServiceGateway>();
builder.Services.AddScoped<ITreeGateway, TreeGateway>();
builder.Services.AddSingleton<IDomainObjectTypeMap, DomainObjectTypeMap>();
builder.Services.AddScoped<IWorkflowServiceGateway, WorkflowServiceGateway>();
builder.Services.AddScoped<IDocumentGeneratorGateway, DocumentGeneratorGateway>();
builder.Services.AddSingleton<IImageCompressionService, ImageCompressionService>();
builder.Services.AddSingleton<ISearchRouteKeyRegistry, SearchRouteKeyRegistry>();
builder.Services.AddSingleton<IDomainObjectRouteKeyRegistry, DomainObjectRouteKeyRegistry>();
builder.Services.AddMudServices();

builder.Services.Configure<ApiClientOptions>(opt =>
{
    opt.ApiClientName = "MyBusinessApp.WebApi";
});

builder.Services.AddHttpClient("MyBusinessApp.WebApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
});

builder.Services.AddLocalization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[] { "fr" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("fr")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

ExcuteModuleRegistrations(app.Services);
RegisterDomainObectPageWorkspaces(app.Services);

app.Run();

void ExcuteModuleRegistrations(IServiceProvider serviceProvider)
{
    var modulePurchaseService = serviceProvider.GetRequiredService<IModuleBootstrapperProviderService>();

    var modules = modulePurchaseService.GetModules();

    foreach (var module in modules)
    {
        module.RegisterLocalizedStrings(serviceProvider);
        module.RegisterBrowserDescriptors(serviceProvider);
        module.RegisterSelectorDescriptors(serviceProvider);
        module.RegisterReferenceSelectors(serviceProvider);
        module.RegisterDomainObjectBrowserWorkspaces(serviceProvider);
        module.RegisterIcons(serviceProvider);
        module.RegisterDomainObjectTypesMapping(serviceProvider);
        module.RegisterDomainObjectRouteKeys(serviceProvider);
    }

    var searchModules = modulePurchaseService.GetSearchModules();

    foreach (var module in searchModules)
    {
        module.RegisterSearchRouteKeys(serviceProvider);
    }

    var localizedStringService = serviceProvider.GetRequiredService<ILocalizedStringService>();

    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.InfosKey, "fr", "Infos");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.HistoryKey, "fr", "Historique");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.CreationKey, "fr", "Création");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.LastModificationKey, "fr", "Dernière modification");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.ByKey, "fr", "par");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.SaveKey, "fr", "Sauvegarder");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.UndoKey, "fr", "Annuler");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.ResultsKey, "fr", "résultat(s)");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.ConfirmationKey, "fr", "Confirmation");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.ErrorKey, "fr", "Erreur");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.OkKey, "fr", "Ok");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.CancelKey, "fr", "Annuler");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.SelectKey, "fr", "Sélection");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.NewKey, "fr", "Nouveau");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.ActionsKey, "fr", "Actions");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.SearchKey, "fr", "Recherche");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.QuickEditKey, "fr", "Édition rapide");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.LogoKey, "fr", "Logo");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.DocumentKey, "fr", "Document");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.DeletedKey, "fr", "Supprimé");
    localizedStringService.Add(BusinessAppFramework.Contracts.StringKeys.WorkflowKey, "fr", "Flux");

    localizedStringService.Add(BusinessAppFramework.Contracts.ActionKeys.CreateActionKey, "fr", "Ajouter");
    localizedStringService.Add(BusinessAppFramework.Contracts.ActionKeys.DeleteActionKey, "fr", "Supprimer");
    localizedStringService.Add(BusinessAppFramework.Contracts.ActionKeys.DetailsActionKey, "fr", "Détails");
    localizedStringService.Add(BusinessAppFramework.Contracts.ActionKeys.VisualiseFileActionKey, "fr", "Document");
    localizedStringService.Add(BusinessAppFramework.Contracts.ActionKeys.DownloadFileActionKey, "fr", "Télécharger");
    localizedStringService.Add(BusinessAppFramework.Contracts.ActionKeys.ImportExportDataActionKey, "fr", "Import/Export");    

    localizedStringService.Add(BusinessAppFramework.Contracts.ConstraintKeys.AllConstraintKey, "fr", "Tout");

    localizedStringService.Add(BusinessAppFramework.Contracts.MessageKeys.DeleteConfirmationMessage, "fr", "Confirmez-vous la suppression ?");
    localizedStringService.Add(BusinessAppFramework.Contracts.MessageKeys.AbordChangesMessage, "fr", "Abandonner les changements ?");
    localizedStringService.Add(BusinessAppFramework.Contracts.MessageKeys.FileNoteFoundMessage, "fr", "Le fichier demandé n'existe pas.");
    localizedStringService.Add(BusinessAppFramework.Contracts.MessageKeys.ServerErrorMessage, "fr", "Le serveur a répondu avec une erreur.");
    localizedStringService.Add(BusinessAppFramework.Contracts.MessageKeys.NotImplementedMessage, "fr", "Fonctionnalité en développement");
    localizedStringService.Add(BusinessAppFramework.Contracts.MessageKeys.CannotExecuteAction, "fr", "Impossible d'exécuter cette action à cette étape du flux");

    localizedStringService.Add(ParentChildRelationKeys.BusinessPartnerAdressRelationKey, "fr", "Adresses");
    localizedStringService.Add(ParentChildRelationKeys.BusinessPartnerContactRelationKey, "fr", "Contacts");
    localizedStringService.Add(ParentChildRelationKeys.BusinessPartnerNoteRelationKey, "fr", "Notes");
    localizedStringService.Add(ParentChildRelationKeys.CompanyAdressRelationKey, "fr", "Adresses");
    localizedStringService.Add(ParentChildRelationKeys.ContactNoteRelationKey, "fr", "Notes");   

    var iconFactory = serviceProvider.GetRequiredService<IIconFactory>();

    iconFactory.RegisterIcon(StringKey.From(BusinessAppFramework.Contracts.ActionKeys.CreateActionKey), Icons.Material.Outlined.Add);
    iconFactory.RegisterIcon(StringKey.From(BusinessAppFramework.Contracts.ActionKeys.DeleteActionKey), Icons.Material.Outlined.Delete);
    iconFactory.RegisterIcon(StringKey.From(BusinessAppFramework.Contracts.ActionKeys.DetailsActionKey), Icons.Material.Outlined.Edit);
    iconFactory.RegisterIcon(StringKey.From(BusinessAppFramework.Contracts.ActionKeys.VisualiseFileActionKey), Icons.Material.Outlined.Description);
    iconFactory.RegisterIcon(StringKey.From(BusinessAppFramework.Contracts.ActionKeys.DownloadFileActionKey), Icons.Material.Outlined.Download);
    iconFactory.RegisterIcon(StringKey.From(BusinessAppFramework.Contracts.ActionKeys.ImportExportDataActionKey), Icons.Material.Outlined.ImportExport);

    iconFactory.RegisterIcon(StringKey.From(ParentChildRelationKeys.BusinessPartnerAdressRelationKey), Icons.Material.Outlined.LocationOn);
    iconFactory.RegisterIcon(StringKey.From(ParentChildRelationKeys.BusinessPartnerContactRelationKey), Icons.Material.Outlined.Contacts);
    iconFactory.RegisterIcon(StringKey.From(ParentChildRelationKeys.BusinessPartnerNoteRelationKey), Icons.Material.Outlined.Note);

    iconFactory.RegisterIcon(StringKey.From(ParentChildRelationKeys.CompanyAdressRelationKey), Icons.Material.Outlined.LocationOn);
    
    iconFactory.RegisterIcon(StringKey.From(ParentChildRelationKeys.ContactNoteRelationKey), Icons.Material.Outlined.Description);
}

void RegisterDomainObectPageWorkspaces(IServiceProvider serviceProvider)
{
    var workspaceDescriptorFactory = serviceProvider.GetRequiredService<IWorkspaceDescriptorFactory>();
    var domainObjectPageWorkspaceKeyRegistry = serviceProvider.GetRequiredService<IDomainObjectPageWorkspaceKeyRegistry>();
    var localizedStringService = serviceProvider.GetRequiredService<ILocalizedStringService>();

    RegisterDefaultDomainObjectPage<Adress>(MyBusinessAppContracts.AddressPageWorkspace);
    RegisterDefaultDomainObjectPage<BusinessPartnerType>(MyBusinessAppContracts.BusinessPartnerTypePageWorkspace);
    RegisterDefaultDomainObjectPage<Contact>(MyBusinessAppContracts.ContactPageWorkspace);    
    RegisterDefaultDomainObjectPage<Country>(MyBusinessAppContracts.CountryPageWorkspace);
    RegisterDefaultDomainObjectPage<Document>(MyBusinessAppContracts.DocumentPageWorkspace);
    RegisterDefaultDomainObjectPage<PostalCode>(MyBusinessAppContracts.PostalCodePageWorkspace);
    RegisterDefaultDomainObjectPage<TeamMember>(MyBusinessAppContracts.TeamMemberPageWorkspace);
    RegisterDefaultDomainObjectPage<User>(MyBusinessAppContracts.UserPageWorkspace);
    RegisterDefaultDomainObjectPage<UserRole>(MyBusinessAppContracts.UserRolePageWorkspace);
    RegisterDefaultDomainObjectPage<UserRolePermission>(MyBusinessAppContracts.UserRolePermissionPageWorkspace);

    localizedStringService.Add(MyBusinessAppContracts.AddressPageWorkspace, "fr", "Adresses");
    localizedStringService.Add(MyBusinessAppContracts.BusinessPartnerPageWorkspace, "fr", "Partenaire");
    localizedStringService.Add(MyBusinessAppContracts.BusinessPartnerTypePageWorkspace, "fr", "Type de partenaire");
    localizedStringService.Add(MyBusinessAppContracts.CompanyPageWorkspace, "fr", "Entreprise");
    localizedStringService.Add(MyBusinessAppContracts.ContactPageWorkspace, "fr", "Contact");
    localizedStringService.Add(MyBusinessAppContracts.CountryPageWorkspace, "fr", "Pays");
    localizedStringService.Add(MyBusinessAppContracts.DocumentPageWorkspace, "fr", "Document");
    localizedStringService.Add(MyBusinessAppContracts.PostalCodePageWorkspace, "fr", "Code postal");
    localizedStringService.Add(MyBusinessAppContracts.TeamMemberPageWorkspace, "fr", "Membre de l'équipe");
    localizedStringService.Add(MyBusinessAppContracts.UserPageWorkspace, "fr", "Utilisateur");
    localizedStringService.Add(MyBusinessAppContracts.UserRolePageWorkspace, "fr", "Rôle utilisateur");
    localizedStringService.Add(MyBusinessAppContracts.UserRolePermissionPageWorkspace, "fr", "Permission");  

    domainObjectPageWorkspaceKeyRegistry.Register<BusinessPartner>(StringKey.From(MyBusinessAppContracts.BusinessPartnerPageWorkspace));

    workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
        StringKey.From(MyBusinessAppContracts.BusinessPartnerPageWorkspace), () => new DomainObjectPageDescriptor<BusinessPartner>
        {
            WorkspaceKey = StringKey.From(MyBusinessAppContracts.BusinessPartnerPageWorkspace),
            ComponentType = typeof(DomainObjectPage<BusinessPartner>),
            ContentComponentType = typeof(BusinessPartnerPage)
        });    

    domainObjectPageWorkspaceKeyRegistry.Register<Company>(StringKey.From(MyBusinessAppContracts.CompanyPageWorkspace));

    workspaceDescriptorFactory.RegisterWorkspaceDescriptor(
        StringKey.From(MyBusinessAppContracts.CompanyPageWorkspace), () => new DomainObjectPageDescriptor<Company>
        {
            WorkspaceKey = StringKey.From(MyBusinessAppContracts.CompanyPageWorkspace),
            ComponentType = typeof(DomainObjectPage<Company>),
            ContentComponentType = typeof(CompanyPage)
        });       
}

void RegisterDefaultDomainObjectPage<T>(string domainObjectPageKey) where T : DomainObject, new()
{
    var workspaceDescriptorFactory = app.Services.GetRequiredService<IWorkspaceDescriptorFactory>();
    var domainObjectPageWorkspaceKeyRegistry = app.Services.GetRequiredService<IDomainObjectPageWorkspaceKeyRegistry>();

    domainObjectPageWorkspaceKeyRegistry.Register<T>(StringKey.From(domainObjectPageKey));

    workspaceDescriptorFactory.RegisterWorkspaceDescriptor(StringKey.From(domainObjectPageKey) , () => new DomainObjectPageDescriptor<T>
    {
        WorkspaceKey = StringKey.From(domainObjectPageKey),
        ComponentType = typeof(DomainObjectPage<T>),
        ContentComponentType = typeof(DefaultDomainObjectPage<T>)
    });
}
