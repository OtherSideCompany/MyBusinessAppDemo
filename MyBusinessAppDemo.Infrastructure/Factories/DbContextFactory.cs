using BusinessAppFramework.Application.AppConfiguration;
using Microsoft.EntityFrameworkCore;
using MyBusinessApp.Application.AppConfiguration;
using MyBusinessApp.Infrastructure.DBContext;

namespace MyBusinessApp.Infrastructure.Factories
{
   public class DbContextFactory : IDbContextFactory<DbContext>
   {
      private IAppConfiguration _appConfiguration;

      public DbContextFactory(IAppConfiguration appConfiguration)
      {
         _appConfiguration = appConfiguration;
      }

      public DbContext CreateDbContext()
      {
         var context = new MyBusinessAppDbContext((MyBusinessAppConfiguration)_appConfiguration);
         return context;
      }
    }
}
