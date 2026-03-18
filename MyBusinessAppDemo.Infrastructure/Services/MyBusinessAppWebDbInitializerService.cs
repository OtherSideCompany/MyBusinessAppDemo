using Accounts.Infrastructure.Seed;
using BaseData.Infrastructure.Seed;
using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace MyBusinessApp.Infrastructure.Services
{
   public class MyBusinessAppWebDbInitializerService : WebDbInitializerService
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public MyBusinessAppWebDbInitializerService(
         IDbContextFactory<DbContext> dbContextFactory) :
         base(dbContextFactory)
      {

      }

      #endregion

      #region Public Methods

      public override async Task InitializeDatabaseAsync()
      {
         await base.InitializeDatabaseAsync();

         using var context = _dbContextFactory.CreateDbContext();

         var assemblies = AppDomain.CurrentDomain.GetAssemblies();

         foreach (var assembly in assemblies)
         {
            if (assembly.IsDynamic || string.IsNullOrWhiteSpace(assembly.FullName) || assembly.FullName.StartsWith("System") || assembly.FullName.StartsWith("Microsoft"))
               continue;

            var resourcesNamesMore = assembly.GetManifestResourceNames();

            var resourceNames = assembly.GetManifestResourceNames()
                                        .Where(name => name.Contains(".vw_", StringComparison.OrdinalIgnoreCase) &&
                                                       name.EndsWith(".sql", StringComparison.OrdinalIgnoreCase));


            foreach (var resourceName in resourceNames)
            {
               var script = ReadSqlScript(resourceName, assembly);
               await context.Database.ExecuteSqlRawAsync(script);
            }
         }

         await SeedDatabaseAsync(context);

      }

      #endregion

      #region Private Methods

      private async Task SeedDatabaseAsync(Microsoft.EntityFrameworkCore.DbContext context)
      {
         var accountsSeedContributor = new AccountsSeedContributor();
         var baseDataKernelSeedContributor = new BaseDataSeedContributor();

         await accountsSeedContributor.SeedDatabaseAsync(context);
         await baseDataKernelSeedContributor.SeedDatabaseAsync(context);
      }

      #endregion
   }
}
