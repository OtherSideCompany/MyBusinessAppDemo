using Accounts.Infrastructure.Entities;
using BusinessAppFramework.Infrastructure.Factories;
using BusinessAppFramework.Infrastructure.Repositories;

namespace Accounts.Infrastructure.Repository
{
   public class ContactRepository : Repository<Domain.DomainObjects.Contact, Contact>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public ContactRepository(RepositoryDependencies repositoryDependencies) : base(repositoryDependencies)
      {
      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
