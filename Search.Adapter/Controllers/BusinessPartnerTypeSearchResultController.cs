using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts;
using Search.Contracts.SearchResults;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{Accounts.Contracts.RouteKeys.BusinessPartnerType}")]
    public class BusinessPartnerTypeSearchResultController : DomainObjectSearchController<BusinessPartnerTypeSearchResult>
    {
        public BusinessPartnerTypeSearchResultController(ISearchService<BusinessPartnerTypeSearchResult> searchService) : base(searchService)
        {
        }
    }
}
