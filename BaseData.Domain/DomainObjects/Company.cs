using BaseData.Contracts;
using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace BaseData.Domain.DomainObjects
{
   [UserRolePermissionKey(BaseDataContracts.CompanyPermissionKey)]
   public class Company : DomainObject
   {
      #region Fields



      #endregion

      #region Properties

      [MaxLength(200)]
      public string Name { get; set; } = GlobalVariables.DefaultString;

      [MaxLength(20)]
      public string VatNumber { get; set; } = GlobalVariables.DefaultString;

      [MaxLength(1000)]
      public string WebsiteUrl { get; set; } = GlobalVariables.DefaultString;

      [MaxLength(50)]
      public string Phone { get; set; } = GlobalVariables.DefaultString;

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Company()
      {

      }

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return Name;
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
