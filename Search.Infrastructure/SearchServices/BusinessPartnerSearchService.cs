using BusinessAppFramework.Application;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Search.Contracts.SearchResults;
using System.Linq.Expressions;

namespace Search.Infrastructure.SearchServices
{
   public class BusinessPartnerSearchService : SearchService<BusinessPartnerSearchResult>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BusinessPartnerSearchService(
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

      protected override Expression<Func<BusinessPartnerSearchResult, bool>> GetFilterConstraint(string lowerFilter, bool extendedSearch, int maxSearchDistance)
      {
         if (extendedSearch)
         {
            return c => Utils.EditDistance(lowerFilter, c.VatNumber.ToLower(), maxSearchDistance) <= maxSearchDistance ||
                        Utils.EditDistance(lowerFilter, c.Name.ToLower(), maxSearchDistance) <= maxSearchDistance ||
                        (c.ClientNumber != null && Utils.EditDistance(lowerFilter, c.ClientNumber.Value.ToString().ToLower(), maxSearchDistance) <= maxSearchDistance) ||
                        (c.ProviderNumber != null && Utils.EditDistance(lowerFilter, c.ProviderNumber.Value.ToString().ToLower(), maxSearchDistance) <= maxSearchDistance);
         }
         else
         {
            return c => c.VatNumber.ToLower().Contains(lowerFilter) ||
                        c.Name.ToLower().Contains(lowerFilter) ||
                        (c.ClientNumber != null && c.ClientNumber.Value.ToString().ToLower().Contains(lowerFilter)) ||
                        (c.ProviderNumber != null && c.ProviderNumber.Value.ToString().ToLower().Contains(lowerFilter));
         }
      }

      #endregion
   }
}
