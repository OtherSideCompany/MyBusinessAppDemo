using OtherSideCore.Adapter.Web.Controllers;
using OtherSideCore.Application.Search;
using Search.Contracts.SearchResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.WebApi.Controllers
{
   public class ProviderOrderSearchController : DomainObjectSearchController<ProviderOrderSearchResult>
   {
      public ProviderOrderSearchController(IDomainObjectSearch<ProviderOrderSearchResult> searchService) : base(searchService)
      {
      }
   }
}
