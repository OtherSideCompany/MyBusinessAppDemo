using BaseData.Application.DomainObjectServices;
using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace BaseData.Infrastructure.Seed
{
   public class BaseDataSeedContributor : ISeedContributor
   {
      public async Task SeedDatabaseAsync(DbContext dbContext)
      {
         await Task.CompletedTask;
      }
   }
}
