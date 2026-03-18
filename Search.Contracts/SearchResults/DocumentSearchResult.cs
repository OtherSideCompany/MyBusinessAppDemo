using BusinessAppFramework.Application.Search;
using BusinessAppFramework.Application.Trees;
using BusinessAppFramework.Domain;

namespace Search.Contracts.SearchResults
{
   public class DocumentSearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties

      public string CreatedByName { get; set; }
      public string FileName { get; set; }
      public string ContentType { get; set; }
      public long ByteSize { get; set; }

      #endregion

      #region Events



      #endregion

      #region Constructor

      public DocumentSearchResult()
      {

      }

      #endregion

      #region Public Methods

      public override NodeSummary GetSummary()
      {
         return new NodeSummary(GlobalVariables.DefaultString, FileName, CreatedByName);
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
