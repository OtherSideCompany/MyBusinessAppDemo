using Accounts.Infrastructure.Context;
using Accounts.Infrastructure.Entities;
using BaseData.Infrastructure.Context;
using BaseData.Infrastructure.Entities;
using BusinessAppFramework.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MyBusinessApp.Application;
using MyBusinessApp.Application.AppConfiguration;
using Search.Contracts.SearchResults;
using Search.Infrastructure.DBContext;

namespace MyBusinessApp.Infrastructure.DBContext
{
   public class MyBusinessAppDbContext : SqlServerDbContext
   {
      #region Fields



      #endregion

      #region Properties

      public virtual DbSet<Adress> Adresses { get; set; }
      public virtual DbSet<BusinessPartner> BusinessPartners { get; set; }
      public virtual DbSet<BusinessPartnerType> BusinessPartnerTypes { get; set; }
      public virtual DbSet<Company> Companies { get; set; }
      public virtual DbSet<Contact> Contacts { get; set; }
      public virtual DbSet<Country> Countries { get; set; }
      public virtual DbSet<Document> Documents { get; set; }
      public virtual DbSet<Note> Notes { get; set; }
      public virtual DbSet<PostalCode> PostalCodes { get; set; }

      public DbSet<AdressSearchResult> AdressSearchResults => Set<AdressSearchResult>();
      public DbSet<BusinessPartnerSearchResult> BusinessPartnerSearchResults => Set<BusinessPartnerSearchResult>();
      public DbSet<BusinessPartnerTypeSearchResult> BusinessPartnerTypeSearchResults => Set<BusinessPartnerTypeSearchResult>();
      public DbSet<CompanySearchResult> CompanySearchResults => Set<CompanySearchResult>();
      public DbSet<ContactSearchResult> ContactSearchResults => Set<ContactSearchResult>();
      public DbSet<CountrySearchResult> CountrySearchResults => Set<CountrySearchResult>();
      public DbSet<PostalCodeSearchResult> PostalCodeSearchResults => Set<PostalCodeSearchResult>();

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public MyBusinessAppDbContext()
      {
         UserId = "app_admin";
         _password = "Djp7d[*:8K<fQ;!CXKp&p4+4o*nbftcQ;4jupu@lV}jR({D?{rB3mUIq?e!(@Dpt";
         DataSource = @"localhost\SQLEXPRESS";
         InitialCatalog = AppInfo.Name;
      }

      public MyBusinessAppDbContext(MyBusinessAppConfiguration customAppConfiguration) : this()
      {
         customAppConfiguration.Load();

         UserId = customAppConfiguration.UserLogin;
         DataSource = customAppConfiguration.DatabaseServerName;
         InitialCatalog = customAppConfiguration.DatabaseName;
      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         var accountsModelBuilderContributor = new AccountsModelBuilderContributor();
         var searchModelBuilderContributor = new SearchModelBuilderContributor();
         var sharedKernelModelBuilderContributor = new BaseDataModelBuilderContributor();

         accountsModelBuilderContributor.Build(modelBuilder);
         searchModelBuilderContributor.Build(modelBuilder);
         sharedKernelModelBuilderContributor.Build(modelBuilder);

         DefineCrossModuleRelationShips(modelBuilder);

         modelBuilder.FinalizeModel();
      }

      private void DefineCrossModuleRelationShips(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Adress>().HasOne<BusinessPartner>().WithMany().HasForeignKey(e => e.BusinessPartnerId).OnDelete(DeleteBehavior.Cascade);
      }

      #endregion
   }
}
