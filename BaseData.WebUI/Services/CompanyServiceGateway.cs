using BaseData.Contracts.ApiRoutes;
using BaseData.Domain.DomainObjects;
using BaseData.WebUI.Interfaces;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Contracts.ApiRoutes;
using BusinessAppFramework.WebUI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;

namespace BaseData.WebUI.Services
{
    public class CompanyServiceGateway : DomainObjectServiceGateway<Company>, ICompanyServiceGateway
    {
        #region Fields

        private string _baseUrl => $"{ApiRouteSegments.Root}/{ApiRouteSegments.DomainObjects}/{BaseData.Contracts.RouteKeys.Company}/{BaseDataRouteSegments.CompanyLogo}";

        #endregion

        #region Properties



        #endregion

        #region Constructor

        public CompanyServiceGateway(
          IHttpClientFactory clientFactory,
          IOptions<ApiClientOptions> apiClientOptions,
          IDomainObjectRouteKeyRegistry domainObjectRouteKeyRegistry,
          ILogger<CompanyServiceGateway> logger,
          ILocalizedStringService localizedStringService,
          IUserDialogService userDialogService) :
            base(clientFactory, apiClientOptions, domainObjectRouteKeyRegistry, logger, localizedStringService, userDialogService)
        {
        }

        #endregion

        public async Task SaveLogoAsync(int domainObjectId, byte[] logoBytes)
        {
            var content = new ByteArrayContent(logoBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            var route = $"{_baseUrl}/{domainObjectId}";
            var response = await CreateClient().PutAsync(route, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<byte[]?> GetLogoAsync(int domainObjectId)
        {
            var client = CreateClient();

            var route = $"{_baseUrl}/{domainObjectId}";
            var response = await client.GetAsync(route);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
