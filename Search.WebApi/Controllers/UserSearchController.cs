using OtherSideCore.Adapter.Web.Controllers;
using OtherSideCore.Application.Search;
using Search.Contracts.SearchResults;

namespace Search.WebApi.Controllers
{
   public class UserSearchController : DomainObjectSearchController<UserSearchResult>
   {
      public UserSearchController(IDomainObjectSearch<UserSearchResult> searchService) : base(searchService)
      {
      }
   }
}
