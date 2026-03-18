using BusinessAppFramework.Application.Search;

namespace Search.Contracts.SearchResults
{
   public class PostalCodeSearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties

      public string Code { get; set; }
      public string City { get; set; }
      public string? CountryAlpha2Code { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public PostalCodeSearchResult()
      {

      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
