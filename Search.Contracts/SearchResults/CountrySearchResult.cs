using BusinessAppFramework.Application.Search;

namespace Search.Contracts.SearchResults
{
   public class CountrySearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties


      public string Name { get; set; }
      public string Alpha2Code { get; set; }
      public string Alpha3Code { get; set; }
      public string NumericCode { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public CountrySearchResult()
      {

      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
