using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Accounts.Domain.DomainObjects
{
    [UserRolePermissionKey(Contracts.AccountsContracts.BusinessPartnerPermissionKey)]
    public class BusinessPartner : DomainObject
    {
        #region Fields



        #endregion

        #region Properties

        [MaxLength(200)]
        public string Name { get; set; } = GlobalVariables.DefaultString;

        [MaxLength(20)]
        public string VatNumber { get; set; } = GlobalVariables.DefaultString;

        public int? ClientNumber { get; set; }

        public int? ProviderNumber { get; set; }

        public DomainObjectReferenceList BusinessPartnerTypesReferences { get; set; } = new();

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public BusinessPartner()
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
