using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts;
using Search.Contracts.SearchResults;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{Accounts.Contracts.RouteKeys.BusinessPartner}")]
    public class BusinessPartnerSearchResultController : DomainObjectSearchController<BusinessPartnerSearchResult>
    {
        public BusinessPartnerSearchResultController(ISearchService<BusinessPartnerSearchResult> searchService) : base(searchService)
        {
        }
    }
}
