using BusinessAppFramework.Adapter.Interfaces;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Search.Adapter.Controllers;
using Search.Contracts.SearchResults;
using Search.Infrastructure.SearchServices;

namespace Search.Bootstrapper
{
    public class SearchModuleBootstrapper : ISearchModule, IWebApiModuleBootstrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISearchService<AdressSearchResult>, AdressSearchService>();
            services.AddScoped<ISearchService<BusinessPartnerSearchResult>, BusinessPartnerSearchService>();
            services.AddScoped<ISearchService<BusinessPartnerTypeSearchResult>, BusinessPartnerTypeSearchService>();
            services.AddScoped<ISearchService<CompanySearchResult>, CompanySearchService>();
            services.AddScoped<ISearchService<ContactSearchResult>, ContactSearchService>();
            services.AddScoped<ISearchService<CountrySearchResult>, CountrySearchService>();
            services.AddScoped<ISearchService<DocumentSearchResult>, DocumentSearchService>();
            services.AddScoped<ISearchService<NoteSearchResult>, NoteSearchService>();
            services.AddScoped<ISearchService<PostalCodeSearchResult>, PostalCodeSearchService>();
        }

        public void RegisterControllers(IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddApplicationPart(typeof(AdressSearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(BusinessPartnerSearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(BusinessPartnerTypeSearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(CompanySearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(ContactSearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(CountrySearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(DocumentSearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(NoteSearchResultController).Assembly);
            mvcBuilder.AddApplicationPart(typeof(PostalCodeSearchResultController).Assembly);
        }

        public void RegisterSearchRouteKeys(IServiceProvider serviceProvider)
        {
            var searchRouteKeyRegistry = serviceProvider.GetRequiredService<ISearchRouteKeyRegistry>();

            searchRouteKeyRegistry.RegisterRouteKey<AdressSearchResult>(BaseData.Contracts.RouteKeys.Address);
            searchRouteKeyRegistry.RegisterRouteKey<BusinessPartnerSearchResult>(Accounts.Contracts.RouteKeys.BusinessPartner);
            searchRouteKeyRegistry.RegisterRouteKey<BusinessPartnerTypeSearchResult>(Accounts.Contracts.RouteKeys.BusinessPartnerType);
            searchRouteKeyRegistry.RegisterRouteKey<CompanySearchResult>(BaseData.Contracts.RouteKeys.Company);
            searchRouteKeyRegistry.RegisterRouteKey<ContactSearchResult>(Accounts.Contracts.RouteKeys.Contact);
            searchRouteKeyRegistry.RegisterRouteKey<CountrySearchResult>(BaseData.Contracts.RouteKeys.Country);
            searchRouteKeyRegistry.RegisterRouteKey<DocumentSearchResult>(BaseData.Contracts.RouteKeys.Document);
            searchRouteKeyRegistry.RegisterRouteKey<NoteSearchResult>(BaseData.Contracts.RouteKeys.Note);
            searchRouteKeyRegistry.RegisterRouteKey<PostalCodeSearchResult>(BaseData.Contracts.RouteKeys.PostalCode);
        }
    }
}
