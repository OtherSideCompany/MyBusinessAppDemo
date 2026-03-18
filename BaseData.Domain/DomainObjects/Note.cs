using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace BaseData.Domain.DomainObjects
{
   [UserRolePermissionKey(Contracts.BaseDataContracts.NotePermissionKey)]
   public class Note : DomainObject
   {
      #region Fields



      #endregion

      #region Properties

      [MaxLength(2000)]
      public string Text { get; set; } = GlobalVariables.DefaultString;

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Note()
      {

      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
