using BaseData.Infrastructure.Entities;
using BusinessAppFramework.Infrastructure.Factories;
using BusinessAppFramework.Infrastructure.Repositories;

namespace BaseData.Infrastructure.Repositories
{
   public class DocumentRepository : Repository<Domain.DomainObjects.Document, Document>
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public DocumentRepository(RepositoryDependencies repositoryDependencies) : base(repositoryDependencies)
      {

      }

      #endregion

      #region Public Methods


      #endregion

      #region Private Methods



      #endregion
   }
}
