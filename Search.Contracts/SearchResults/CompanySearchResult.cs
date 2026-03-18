using BusinessAppFramework.Application.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace Search.Contracts.SearchResults
{
   public class CompanySearchResult : DomainObjectSearchResult
   {
      #region Fields



      #endregion

      #region Properties

      public string Name { get; set; } = default!;
      public string VatNumber { get; set; } = default!;

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public CompanySearchResult()
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
