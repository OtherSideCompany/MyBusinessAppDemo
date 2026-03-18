using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace BaseData.Domain.DomainObjects
{
    [UserRolePermissionKey(Contracts.BaseDataContracts.AdressPermissionKey)]
    public class Adress : DomainObject
    {
        #region Fields


        #endregion

        #region Properties

        [MaxLength(200)]
        public string Label { get; set; } = GlobalVariables.DefaultString;

        [MaxLength(200)]
        public string AdressDescription { get; set; } = GlobalVariables.DefaultString;

        public DomainObjectReference PostalCodeReference { get; set; } = new();

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public Adress()
        {

        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            var description = "";

            if (!String.IsNullOrEmpty(Label) && !Label.Equals(GlobalVariables.DefaultString))
            {
                description = Label + " - ";
            }

            description += AdressDescription;

            if (PostalCodeReference != null && !String.IsNullOrEmpty(PostalCodeReference.DisplayValue))
            {
                description += ", " + PostalCodeReference.DisplayValue;
            }

            return description;
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
