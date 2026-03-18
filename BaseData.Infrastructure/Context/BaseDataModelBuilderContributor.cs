using BaseData.Infrastructure.Entities;
using BusinessAppFramework.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseData.Infrastructure.Context
{
   public class BaseDataModelBuilderContributor : IModelBuilderContributor
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
         modelBuilder.Entity<Adress>().OwnsOne(e => e.HistoryInfo);
         modelBuilder.Entity<Company>().OwnsOne(e => e.HistoryInfo);
         modelBuilder.Entity<Country>().OwnsOne(e => e.HistoryInfo);
         modelBuilder.Entity<Document>().OwnsOne(e => e.HistoryInfo);
         modelBuilder.Entity<Note>().OwnsOne(e => e.HistoryInfo);
         modelBuilder.Entity<PostalCode>().OwnsOne(e => e.HistoryInfo);

         modelBuilder.Entity<Adress>().Navigation(a => a.PostalCode).AutoInclude();
         modelBuilder.Entity<PostalCode>().Navigation(pc => pc.Country).AutoInclude();

         modelBuilder.Entity<Adress>().HasOne<Company>().WithMany(c => c.Adresses).HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Cascade);
      }

      #endregion
   }
}
