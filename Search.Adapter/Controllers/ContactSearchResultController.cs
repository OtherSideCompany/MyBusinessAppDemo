using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts;
using Search.Contracts.SearchResults;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{Accounts.Contracts.RouteKeys.Contact}")]
    public class ContactSearchResultController : DomainObjectSearchController<ContactSearchResult>
    {
        public ContactSearchResultController(ISearchService<ContactSearchResult> searchService) : base(searchService)
        {
        }
    }
}
