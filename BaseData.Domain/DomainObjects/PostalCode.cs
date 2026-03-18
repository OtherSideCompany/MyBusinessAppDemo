using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace BaseData.Domain.DomainObjects
{
   [UserRolePermissionKey(Contracts.BaseDataContracts.PostalCodePermissionKey)]
   public class PostalCode : DomainObject
   {
      #region Fields



      #endregion

      #region Properties

      [MaxLength(20)]
      public string Code { get; set; } = GlobalVariables.DefaultString;

      [MaxLength(255)]
      public string City { get; set; } = GlobalVariables.DefaultString;

      public DomainObjectReference CountryReference { get; set; } = new();

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public PostalCode()
      {

      }

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return Code + " " + City;
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
