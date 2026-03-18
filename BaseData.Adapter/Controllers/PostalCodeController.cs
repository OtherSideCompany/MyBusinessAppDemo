using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts.SearchResults;

namespace BaseData.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.DomainObjects}/{BaseData.Contracts.RouteKeys.PostalCode}")]
    public class PostalCodeController : DomainObjectController<PostalCode, PostalCodeSearchResult>
    {
        public PostalCodeController(IDomainObjectServiceFactory domainObjectServiceFactory) : base(domainObjectServiceFactory)
        {
        }
    }
}
