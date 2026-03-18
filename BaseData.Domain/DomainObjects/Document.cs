using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;

namespace BaseData.Domain.DomainObjects
{
   [UserRolePermissionKey(Contracts.BaseDataContracts.DocumentPermissionKey)]
   public class Document : DomainObject
   {
      #region Fields



      #endregion

      #region Properties

      [SystemProperty]
      public string FileName { get; set; } = GlobalVariables.DefaultString;

      [SystemProperty]
      public string ContentType { get; set; } = GlobalVariables.DefaultString;

      [SystemProperty]
      public long ByteSize { get; set; }

      [SystemProperty]
      public Guid StorageKey { get; set; } = Guid.CreateVersion7();

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Document()
      {

      }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return FileName;
        }

      #endregion

      #region Private Methods



      #endregion
   }
}
