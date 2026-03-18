using Accounts.Domain.DomainObjects;
using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts.SearchResults;
namespace Accounts.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.DomainObjects}/{Accounts.Contracts.RouteKeys.BusinessPartner}")]
    public class BusinessPartnerController : DomainObjectController<BusinessPartner, BusinessPartnerSearchResult>
    {
        public BusinessPartnerController(IDomainObjectServiceFactory domainObjectServiceFactory) : base(domainObjectServiceFactory)
        {
        }
    }
}
