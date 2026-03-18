using Accounts.Application.RepositoryInterfaces;
using Accounts.Infrastructure.Entities;
using BusinessAppFramework.Infrastructure.Factories;
using BusinessAppFramework.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Accounts.Infrastructure.Repository
{
   public class BusinessPartnerRepository : Repository<Domain.DomainObjects.BusinessPartner, BusinessPartner>, IBusinessPartnerRepository
   {
      #region Fields


      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BusinessPartnerRepository(RepositoryDependencies repositoryDependencies) : base(repositoryDependencies)
      {
         _canUseExecuteDelete = false;
      }

      #endregion

      #region Public Methods

      public async Task<int?> GetMaxClientNumberAsync()
      {
         _logger.LogInformation($"{GetType()}, {nameof(GetMaxClientNumberAsync)}");

         using (var context = _dbContextFactory.CreateDbContext())
         {
            var maxNumber = await context.Set<BusinessPartner>()
                                         .Where(bp => bp.BusinessPartnerTypes.Select(bpt => bpt.SystemCode).Contains(Domain.DomainObjects.BusinessPartnerType.ClientSystemCode) &&
                                                      bp.ClientNumber.HasValue)
                                         .MaxAsync(bp => bp.ClientNumber);

            return maxNumber.HasValue ? maxNumber.Value : 0;
         }
      }

      public async Task<int?> GetMaxProviderNumberAsync()
      {
         _logger.LogInformation($"{GetType()}, {nameof(GetMaxProviderNumberAsync)}");

         using (var context = _dbContextFactory.CreateDbContext())
         {
            var maxNumber = await context.Set<BusinessPartner>()
                                         .Where(bp => bp.BusinessPartnerTypes.Select(bpt => bpt.SystemCode).Contains(Domain.DomainObjects.BusinessPartnerType.ProviderSystemCode) &&
                                                      bp.ProviderNumber.HasValue)
                                         .MaxAsync(bp => bp.ProviderNumber);

            return maxNumber.HasValue ? maxNumber.Value : 0;
         }
      }

      public async Task<bool> IsClientAsync(int businessPartnerId)
      {
         _logger.LogInformation($"{GetType()}, {nameof(IsClientAsync)}, businessPartnerId = {businessPartnerId}");

         using (var context = _dbContextFactory.CreateDbContext())
         {
            return await context.Set<BusinessPartner>()
                                .Where(bp => bp.Id == businessPartnerId)
                                .AnyAsync(bp => bp.BusinessPartnerTypes.Any(t => t.SystemCode == Domain.DomainObjects.BusinessPartnerType.ClientSystemCode));
         }
      }

      public async Task<bool> IsPurchaseAsync(int businessPartnerId)
      {
         _logger.LogInformation($"{GetType()}, {nameof(IsPurchaseAsync)}, businessPartnerId = {businessPartnerId}");

         using (var context = _dbContextFactory.CreateDbContext())
         {
            return await context.Set<BusinessPartner>()
                                .Where(bp => bp.Id == businessPartnerId)
                                .AnyAsync(bp => bp.BusinessPartnerTypes.Any(t => t.SystemCode == Domain.DomainObjects.BusinessPartnerType.ProviderSystemCode));
         }
      }

      public async Task SetRoleAsync(int businessPartnerId, string role)
      {
         _logger.LogInformation($"{GetType()}, {nameof(SetRoleAsync)}, businessPartnerId = {businessPartnerId}, role = {role}");

         using var context = _dbContextFactory.CreateDbContext();

         var businessPartner = await context.Set<BusinessPartner>().Include(bp => bp.BusinessPartnerTypes).FirstAsync(bp => bp.Id == businessPartnerId);

         if (!businessPartner.BusinessPartnerTypes.Any(t => t.SystemCode == role))
         {
            var roleToAssign = await context.Set<BusinessPartnerType>().FirstAsync(t => t.SystemCode == role);
            businessPartner.BusinessPartnerTypes.Add(roleToAssign);
            await context.SaveChangesAsync();
         }
      }

      public async Task<IEnumerable<int>> GetTypeIdsAsync(int businessPartnerId)
      {
         _logger.LogInformation($"{GetType()}, {nameof(GetTypeIdsAsync)}, businessPartnerId = {businessPartnerId}");

         using var context = _dbContextFactory.CreateDbContext();

         return await context.Set<BusinessPartner>()
                             .Where(bp => bp.Id == businessPartnerId)
                             .SelectMany(bp => bp.BusinessPartnerTypes.Select(t => t.Id))
                             .ToListAsync();
      }

      public async Task SetTypesAsync(int businessPartnerId, List<int> typeIds)
      {
         _logger.LogInformation($"{GetType()}, {nameof(GetTypeIdsAsync)}, businessPartnerId = {businessPartnerId}");

         using var context = _dbContextFactory.CreateDbContext();

         var businessPartner = await context.Set<BusinessPartner>().Include(bp => bp.BusinessPartnerTypes).FirstAsync(bp => bp.Id == businessPartnerId);
         var typesToAssign = await context.Set<BusinessPartnerType>().Where(t => typeIds.Contains(t.Id)).ToListAsync();

         businessPartner.BusinessPartnerTypes.Clear();

         foreach (var type in typesToAssign)
         {
            businessPartner.BusinessPartnerTypes.Add(type);
         }

         await context.SaveChangesAsync();
      }

      #endregion

      #region Private Methods



      #endregion

   }
}
