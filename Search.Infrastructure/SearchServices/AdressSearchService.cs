using BusinessAppFramework.Application;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Search.Contracts.SearchResults;
using System.Linq.Expressions;

namespace Search.Infrastructure.SearchServices
{
   public class AdressSearchService : SearchService<AdressSearchResult>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public AdressSearchService(
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

      protected override Expression<Func<AdressSearchResult, bool>> GetFilterConstraint(string lowerFilter, bool extendedSearch, int maxSearchDistance)
      {
         if (extendedSearch)
         {
            return c => Utils.EditDistance(lowerFilter, c.Label.ToLower(), maxSearchDistance) <= maxSearchDistance ||
                        (c.ParentName != null && Utils.EditDistance(lowerFilter, c.ParentName.ToLower(), maxSearchDistance) <= maxSearchDistance) ||
                        Utils.EditDistance(lowerFilter, c.AdressDescription.ToLower(), maxSearchDistance) <= maxSearchDistance ||
                        (c.City != null && Utils.EditDistance(lowerFilter, c.City.ToLower(), maxSearchDistance) <= maxSearchDistance) ||
                        (c.PostalCode != null && Utils.EditDistance(lowerFilter, c.PostalCode.ToLower(), maxSearchDistance) <= maxSearchDistance) ||
                        (c.CountryAlpha2Code != null && Utils.EditDistance(lowerFilter, c.CountryAlpha2Code.ToLower(), maxSearchDistance) <= maxSearchDistance);
         }
         else
         {
            return c => c.Label.ToLower().Contains(lowerFilter) ||
                        (c.ParentName != null && c.ParentName.ToLower().Contains(lowerFilter)) ||
                        c.AdressDescription.ToLower().Contains(lowerFilter) ||
                        (c.City != null && c.City.ToLower().Contains(lowerFilter)) ||
                        (c.PostalCode != null && c.PostalCode.ToLower().Contains(lowerFilter)) ||
                        (c.CountryAlpha2Code != null && c.CountryAlpha2Code.ToLower().Contains(lowerFilter));
         }
      }

      #endregion

   }
}
