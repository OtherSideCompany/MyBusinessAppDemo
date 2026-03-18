using BusinessAppFramework.Application.Search;
using BusinessAppFramework.Application.Trees;
using BusinessAppFramework.Domain;

namespace Search.Contracts.SearchResults
{
   public class ContactSearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties

      public int? ParentId { get; set; }
      public string? ParentName { get; set; }
      public string Name { get; set; }
      public bool IsActive { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public ContactSearchResult()
      {

      }

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return Name;
      }

      public override NodeSummary GetSummary()
      {
         return new NodeSummary(GlobalVariables.DefaultString, Name, ParentName ?? GlobalVariables.DefaultString);
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
