using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts.SearchResults;

namespace BaseData.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.DomainObjects}/{BaseData.Contracts.RouteKeys.Address}")]
    public class AdressController : DomainObjectController<Adress, AdressSearchResult>
    {
        public AdressController(IDomainObjectServiceFactory domainObjectServiceFactory) : base(domainObjectServiceFactory)
        {
        }
    }
}
