using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts.SearchResults;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{BaseData.Contracts.RouteKeys.Address}")]
    public class AdressSearchResultController : DomainObjectSearchController<AdressSearchResult>
    {
        public AdressSearchResultController(ISearchService<AdressSearchResult> searchService) : base(searchService)
        {
        }
    }
}
