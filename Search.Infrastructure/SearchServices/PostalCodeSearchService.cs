using BusinessAppFramework.Application;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Search.Contracts.SearchResults;
using System.Linq.Expressions;

namespace Search.Infrastructure.SearchServices
{
   public class PostalCodeSearchService : SearchService<PostalCodeSearchResult>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public PostalCodeSearchService(
         IDbContextFactory<DbContext> dbContextFactory,
         ILoggerFactory loggerFactory,
         IConstraintFactory constraintFactory) :
         base(dbContextFactory, loggerFactory, constraintFactory)
      {

      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods

      protected override Expression<Func<PostalCodeSearchResult, bool>> GetFilterConstraint(string lowerFilter, bool extendedSearch, int maxSearchDistance)
      {
         if (extendedSearch)
         {
            return pc => Utils.EditDistance(lowerFilter, pc.Code.ToLower(), maxSearchDistance) <= maxSearchDistance ||
                         Utils.EditDistance(lowerFilter, pc.City.ToLower(), maxSearchDistance) <= maxSearchDistance;
         }
         else
         {
            return pc => pc.Code.ToLower().Contains(lowerFilter) ||
                         pc.City.ToLower().Contains(lowerFilter);
         }
      }

      #endregion
   }
}
