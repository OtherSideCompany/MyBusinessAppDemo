using BusinessAppFramework.Application;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Search.Contracts.SearchResults;
using System.Linq.Expressions;
namespace Search.Infrastructure.SearchServices
{
   public class NoteSearchService : SearchService<NoteSearchResult>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Events



      #endregion

      #region Constructor

      public NoteSearchService(
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

      protected override Expression<Func<NoteSearchResult, bool>> GetFilterConstraint(string lowerFilter, bool extendedSearch, int maxSearchDistance)
      {
         if (extendedSearch)
         {
            return c => Utils.EditDistance(lowerFilter, c.Text.ToLower(), maxSearchDistance) <= maxSearchDistance ||
                        Utils.EditDistance(lowerFilter, c.CreatedByName.ToLower(), maxSearchDistance) <= maxSearchDistance;
         }
         else
         {
            return c => c.Text.ToLower().Contains(lowerFilter) ||
                        c.CreatedByName.ToLower().Contains(lowerFilter);
         }
      }

      #endregion
   }
}
