using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts;
using Search.Contracts.SearchResults;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{BaseData.Contracts.RouteKeys.PostalCode}")]
    public class PostalCodeSearchResultController : DomainObjectSearchController<PostalCodeSearchResult>
    {
        public PostalCodeSearchResultController(ISearchService<PostalCodeSearchResult> searchService) : base(searchService)
        {
        }
    }
}
