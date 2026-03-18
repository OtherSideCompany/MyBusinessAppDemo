using BaseData.Application.Interfaces;
using BaseData.Contracts;
using BaseData.Contracts.ApiRoutes;
using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Adapter.Controllers;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Contracts;
using BusinessAppFramework.Contracts.ApiRoutes;
using Microsoft.AspNetCore.Mvc;
using Search.Contracts.SearchResults;

namespace BaseData.Adapter.Controllers
{
    [Route($"{ApiRouteSegments.Root}/{ApiRouteSegments.DomainObjects}/{BaseData.Contracts.RouteKeys.Company}")]
    public class CompanyController : DomainObjectController<Company, CompanySearchResult>
    {
        public CompanyController(IDomainObjectServiceFactory domainObjectServiceFactory) : base(domainObjectServiceFactory)
        {
        }

        [HttpPut($"{BaseDataRouteSegments.CompanyLogo}/{{{ApiRouteParams.DomainObjectId}:int}}")]
        public async Task<IActionResult> SaveLogo(
            [FromRoute(Name = ApiRouteParams.DomainObjectId)] int domainObjectId)
        {
            using var ms = new MemoryStream();
            await Request.Body.CopyToAsync(ms);

            var logoBytes = ms.ToArray();

            var companyService = (ICompanyService)_domainObjectServiceFactory.CreateDomainObjectService<Company>();
            await companyService.SetLogoAsync(domainObjectId, logoBytes);

            return Ok();
        }

        [HttpGet($"{BaseDataRouteSegments.CompanyLogo}/{{{ApiRouteParams.DomainObjectId}:int}}")]
        public async Task<IActionResult> GetLogo(
            [FromRoute(Name = ApiRouteParams.DomainObjectId)] int domainObjectId)
        {
            var companyService = (ICompanyService)_domainObjectServiceFactory.CreateDomainObjectService<Company>();

            var logoBytes = await companyService.GetLogoAsync(domainObjectId);

            if (logoBytes == null || logoBytes.Length == 0)
                return NotFound();

            return File(logoBytes, "image/png");
        }
    }
}
