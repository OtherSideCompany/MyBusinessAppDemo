using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts;
using Search.Contracts.SearchResults;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{BaseData.Contracts.RouteKeys.Company}")]
    public class CompanySearchResultController : DomainObjectSearchController<CompanySearchResult>
    {
        public CompanySearchResultController(ISearchService<CompanySearchResult> searchService) : base(searchService)
        {
        }
    }
}
