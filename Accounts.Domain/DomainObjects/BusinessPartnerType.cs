using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Accounts.Domain.DomainObjects
{
    [UserRolePermissionKey(Contracts.AccountsContracts.BusinessPartnerTypePermissionKey)]
    public class BusinessPartnerType : DomainObject, ISystemObject
    {
        #region Fields

        public const string ClientSystemCode = "C";
        public const string ProviderSystemCode = "P";

        #endregion

        #region Properties

        [MaxLength(100)]
        public string Name { get; set; } = GlobalVariables.DefaultString;

        [SystemProperty]
        public string? SystemCode { get; set; }

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public BusinessPartnerType()
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
