using BusinessAppFramework.Application.Search;

namespace Search.Contracts.SearchResults
{
   public class BusinessPartnerSearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties

      public string Name { get; set; }
      public string VatNumber { get; set; }
      public int? ClientNumber { get; set; }
      public int? ProviderNumber { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BusinessPartnerSearchResult()
      {

      }

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return Name;
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
