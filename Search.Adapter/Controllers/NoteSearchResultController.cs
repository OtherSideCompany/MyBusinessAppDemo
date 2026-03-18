using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts;
using Search.Contracts.SearchResults;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{BaseData.Contracts.RouteKeys.Note}")]
    public class NoteSearchResultController : DomainObjectSearchController<NoteSearchResult>
    {
        public NoteSearchResultController(ISearchService<NoteSearchResult> searchService) : base(searchService)
        {
        }
    }
}
