using BusinessAppFramework.Application.Search;
using BusinessAppFramework.Application.Trees;
using BusinessAppFramework.Domain;

namespace Search.Contracts.SearchResults
{
   public class AdressSearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties

      public string? ParentName { get; set; }
      public string Label { get; set; }
      public string AdressDescription { get; set; }
      public string? City { get; set; }
      public string? PostalCode { get; set; }
      public string? CountryAlpha2Code { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public AdressSearchResult()
      {

      }

      #endregion

      #region Public Methods

      public override NodeSummary GetSummary()
      {
         return new NodeSummary(GlobalVariables.DefaultString, Label, (AdressDescription + " " + PostalCode + " " + CountryAlpha2Code).Trim());
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
