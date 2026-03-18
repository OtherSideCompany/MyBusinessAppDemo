using Accounts.Application.RepositoryInterfaces;
using Accounts.Domain.DomainObjects;
using BusinessAppFramework.Application.Repository;
using BusinessAppFramework.Application.Services;

namespace Accounts.Application.DomainObjectServices
{
   public class BusinessPartnerService : DomainObjectService<BusinessPartner>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor
      public BusinessPartnerService(
         IRepository<BusinessPartner> repository,
         DomainObjectServiceDependencies domainObjectServiceDependencies) :
         base(repository, domainObjectServiceDependencies)
      {

      }


      #endregion

      #region Public Methods

      public async Task<int> GetNextClientNumberAsync()
      {
         int? maxNumber = await WithReadPermissionAsync(() => ((IBusinessPartnerRepository)_repository).GetMaxClientNumberAsync());
         return maxNumber.HasValue ? maxNumber.Value + 1 : 1;
      }

      public async Task<int> GetNextProviderNumberAsync()
      {
         int? maxNumber = await WithReadPermissionAsync(() => ((IBusinessPartnerRepository)_repository).GetMaxProviderNumberAsync());
         return maxNumber.HasValue ? maxNumber.Value + 1 : 1;
      }

      public async Task<IEnumerable<int>> GetTypeIdsAsync(int businessPartnerId)
      {
         return await WithReadPermissionAsync(() => ((IBusinessPartnerRepository)_repository).GetTypeIdsAsync(businessPartnerId));
      }

      public async Task SetTypesAsync(int businessPartnerId, List<int> typeIds)
      {
         await WithUpdatePermissionAsync(() => ((IBusinessPartnerRepository)_repository).SetTypesAsync(businessPartnerId, typeIds));
      }

      #endregion

      #region Private Methods


      #endregion

   }
}
