using BusinessAppFramework.Application.Search;
using BusinessAppFramework.Application.Trees;
using BusinessAppFramework.Domain;

namespace Search.Contracts.SearchResults
{
   public class NoteSearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties

      public string Text { get; set; }
      public string CreatedByName { get; set; }

      #endregion

      #region Events



      #endregion

      #region Constructor

      public NoteSearchResult()
      {

      }

      #endregion

      #region Public Methods

      public override NodeSummary GetSummary()
      {
         return new NodeSummary(GlobalVariables.DefaultString, CreatedByName, Text);
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
