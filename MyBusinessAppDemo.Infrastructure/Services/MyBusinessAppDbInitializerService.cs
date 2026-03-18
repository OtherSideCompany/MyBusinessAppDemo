using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace MyBusinessApp.Infrastructure.Services
{
   public class MyBusinessAppDbInitializerService : DbInitializerService
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public MyBusinessAppDbInitializerService(
         IDbContextFactory<DbContext> dbContextFactory) :
         base(dbContextFactory)
      {

      }

      #endregion

      #region Public Methods

      public override async Task InitializeDatabaseAsync()
      {
         await base.InitializeDatabaseAsync();

         using (var context = _dbContextFactory.CreateDbContext())
         {
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
         }
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
