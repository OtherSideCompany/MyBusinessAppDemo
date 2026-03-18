using BaseData.Application.Interfaces;
using BaseData.Application.RepositoryInterfaces;
using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Application.Repository;
using BusinessAppFramework.Application.Services;

namespace BaseData.Application.DomainObjectServices
{
   public class CompanyService : DomainObjectService<Company>, ICompanyService
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public CompanyService(
         IRepository<Company> repository,
         DomainObjectServiceDependencies domainObjectServiceGlobalDependencies) :
         base(repository, domainObjectServiceGlobalDependencies)
      {

      }      

      #endregion

      #region Public Methods

      public async Task SetLogoAsync(int domainObjectId, byte[] logoBytes)
      {
         await WithUpdatePermissionAsync(() => ((ICompanyRepository)_repository).SetLogoAsync(domainObjectId, logoBytes));
      }

      public async Task<byte[]> GetLogoAsync(int domainObjectId)
      {
         return await WithReadPermissionAsync(() => ((ICompanyRepository)_repository).GetLogoAsync(domainObjectId));
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
