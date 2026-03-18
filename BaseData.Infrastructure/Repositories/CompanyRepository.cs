using BaseData.Application.RepositoryInterfaces;
using BaseData.Infrastructure.Entities;
using BusinessAppFramework.Infrastructure.Factories;
using BusinessAppFramework.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BaseData.Infrastructure.Repositories
{
   public class CompanyRepository : Repository<Domain.DomainObjects.Company, Company>, ICompanyRepository
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public CompanyRepository(RepositoryDependencies repositoryDependencies) : base(repositoryDependencies)
      {

      }      

      #endregion

      #region Public Methods

      public async Task SetLogoAsync(int domainObjectId, byte[] logoBytes)
      {
         _logger.LogInformation($"{nameof(SetLogoAsync)}, domainObjectId={domainObjectId}");

         using var context = _dbContextFactory.CreateDbContext();

         await context.Set<Company>().Where(c => c.Id == domainObjectId).ExecuteUpdateAsync(s => s.SetProperty(c => c.Logo, logoBytes));
      }

      public async Task<byte[]> GetLogoAsync(int domainObjectId)
      {
         _logger.LogInformation($"{nameof(GetLogoAsync)}, domainObjectId={domainObjectId}");

         using var context = _dbContextFactory.CreateDbContext();

         var company = await context.Set<Company>().FindAsync(domainObjectId);

         return company?.Logo ?? Array.Empty<byte>();
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
