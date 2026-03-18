using Microsoft.AspNetCore.Mvc;
using OtherSideCore.Adapter.Web.Controllers;
using OtherSideCore.Application.Search;
using Search.Contracts.SearchResults;

namespace Search.WebApi.Controllers
{
   public class AdressSearchController : DomainObjectSearchController<AdressSearchResult>
   {
      public AdressSearchController(IDomainObjectSearch<AdressSearchResult> searchService) : base(searchService)
      {
      }
   }
}
