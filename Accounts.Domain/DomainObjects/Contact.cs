using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.Attributes;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Accounts.Domain.DomainObjects
{
    [UserRolePermissionKey(Contracts.AccountsContracts.ContactPermissionKey)]
    public class Contact : DomainObject
    {
        #region Fields



        #endregion

        #region Properties

        [MaxLength(200)]
        public string Name { get; set; } = GlobalVariables.DefaultString;

        [MaxLength(100)]
        public string Phone { get; set; } = GlobalVariables.DefaultString;

        [MaxLength(300)]
        public string Mail { get; set; } = GlobalVariables.DefaultString;

        public bool IsActive { get; set; }

        public DomainObjectReference BusinessPartnerReference { get; set; } = new();


        #endregion

        #region Commands



        #endregion

        #region Constructor

        public Contact()
        {
            IsActive = true;
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
