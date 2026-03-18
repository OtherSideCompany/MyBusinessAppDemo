using BusinessAppFramework.Application;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Search.Contracts.SearchResults;
using System.Linq.Expressions;

namespace Search.Infrastructure.SearchServices
{
   public class BusinessPartnerTypeSearchService : SearchService<BusinessPartnerTypeSearchResult>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BusinessPartnerTypeSearchService(
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

      protected override Expression<Func<BusinessPartnerTypeSearchResult, bool>> GetFilterConstraint(string lowerFilter, bool extendedSearch, int maxSearchDistance)
      {
         if (extendedSearch)
         {
            return c => Utils.EditDistance(lowerFilter, c.Name.ToLower(), maxSearchDistance) <= maxSearchDistance;
         }
         else
         {
            return c => c.Name.ToLower().Contains(lowerFilter);
         }
      }

      #endregion
   }
}
