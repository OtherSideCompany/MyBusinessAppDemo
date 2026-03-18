using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace BaseData.Domain.DomainObjects
{
   [UserRolePermissionKey(Contracts.BaseDataContracts.CountryPermissionKey)]
   public class Country : DomainObject
   {
      #region Fields



      #endregion

      #region Properties

      [MaxLength(50)]
      public string Name { get; set; } = GlobalVariables.DefaultString;

      [StringLength(2)]
      public string Alpha2Code { get; set; } = "XX";

      [StringLength(3)]
      public string Alpha3Code { get; set; } = "XXX";

      [StringLength(3)]
      public string NumericCode { get; set; } = "000";

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Country()
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
