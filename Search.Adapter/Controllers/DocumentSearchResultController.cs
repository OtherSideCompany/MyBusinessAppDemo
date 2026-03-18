using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts;
using Search.Contracts.SearchResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Search.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.Search}/{BaseData.Contracts.RouteKeys.Document}")]
    public class DocumentSearchResultController : DomainObjectSearchController<DocumentSearchResult>
    {
        public DocumentSearchResultController(ISearchService<DocumentSearchResult> searchService) : base(searchService)
        {
        }
    }
}
