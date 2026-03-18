using BusinessAppFramework.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Search.Contracts.SearchResults;

namespace Search.Infrastructure.DBContext
{
    public class SearchModelBuilderContributor : IModelBuilderContributor
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Commands



        #endregion

        #region Constructor

        public SearchModelBuilderContributor()
        {

        }

        #endregion

        #region Public Methods

        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdressSearchResult>().ToView("vw_" + nameof(AdressSearchResult)).HasNoKey();
            modelBuilder.Entity<BusinessPartnerSearchResult>().ToView("vw_" + nameof(BusinessPartnerSearchResult)).HasNoKey();
            modelBuilder.Entity<BusinessPartnerTypeSearchResult>().ToView("vw_" + nameof(BusinessPartnerTypeSearchResult)).HasNoKey();
            modelBuilder.Entity<CompanySearchResult>().ToView("vw_" + nameof(CompanySearchResult)).HasNoKey();
            modelBuilder.Entity<ContactSearchResult>().ToView("vw_" + nameof(ContactSearchResult)).HasNoKey();
            modelBuilder.Entity<CountrySearchResult>().ToView("vw_" + nameof(CountrySearchResult)).HasNoKey();
            modelBuilder.Entity<DocumentSearchResult>().ToView("vw_" + nameof(DocumentSearchResult)).HasNoKey();
            modelBuilder.Entity<NoteSearchResult>().ToView("vw_" + nameof(NoteSearchResult)).HasNoKey();
            modelBuilder.Entity<PostalCodeSearchResult>().ToView("vw_" + nameof(PostalCodeSearchResult)).HasNoKey();
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
