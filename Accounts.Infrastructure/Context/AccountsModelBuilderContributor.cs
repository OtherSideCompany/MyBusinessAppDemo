using Accounts.Infrastructure.Entities;
using BusinessAppFramework.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastructure.Context
{
   public class AccountsModelBuilderContributor : IModelBuilderContributor
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor


      #endregion

      #region Public Methods

      public void Build(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<BusinessPartner>().OwnsOne(e => e.HistoryInfo);
         modelBuilder.Entity<BusinessPartnerType>().OwnsOne(e => e.HistoryInfo);
         modelBuilder.Entity<Contact>().OwnsOne(e => e.HistoryInfo);

         modelBuilder.Entity<Contact>().Navigation(c => c.BusinessPartner).AutoInclude();

         modelBuilder.Entity<BusinessPartner>().HasMany(bp => bp.BusinessPartnerTypes).WithMany();
      }

      #endregion

      #region Private Methods


      #endregion
   }
}
