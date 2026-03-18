using Accounts.Domain.DomainObjects;
using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts.SearchResults;

namespace Accounts.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.DomainObjects}/{Accounts.Contracts.RouteKeys.BusinessPartnerType}")]
    public class BusinessPartnerTypeController : DomainObjectController<BusinessPartnerType, BusinessPartnerTypeSearchResult>
    {
        public BusinessPartnerTypeController(IDomainObjectServiceFactory domainObjectServiceFactory) : base(domainObjectServiceFactory)
        {
        }
    }
}
