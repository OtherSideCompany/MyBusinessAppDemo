using Accounts.Desktop;
using Accounts.Desktop.Workspaces.BusinessPartner;
using Accounts.Desktop.Workspaces.Contacts;
using OtherSideCore.Wpf.Services;
using BaseData.Desktop;
using OtherSideCore.Application;
using Accounts.Contracts;
using BaseData.Contracts;
using BaseData.Desktop.Workspaces.PostalCodes;
using BaseData.Desktop.Selector;
using BaseData.Desktop.Workspaces.TeamMembers;
using BaseData.Desktop.Workspaces.Countries;
using Accounts.Desktop.Workspaces.BusinessPartnerType;
using BaseData.Desktop.Workspaces.User;
using OtherSideCore.Domain;
using BaseData.Desktop.Workspaces.Permissions;
using Accounts.Workspaces.Desktop;
using BaseData.Desktop.Workspaces;
using Purchases.Contracts;
using Purchases.Desktop.Workspaces;
using Purchases.Adapter.Workspaces;
using Purchases.Desktop.Workspaces.ProviderOrder;
using Purchases.Desktop.Workspaces.ProviderQuote;
using Accounts.Desktop.Selector;

namespace Manufacturing.Desktop.Services
{
   public class ManufacturingViewLocatorService : ViewLocatorService
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public ManufacturingViewLocatorService()
      {
         Register(StringKey.From(AccountsContracts.AccountsModule), typeof(AccountsModuleView));
         Register(StringKey.From(AccountsContracts.BusinessPartnerTypeWorkspace), typeof(BusinessPartnerTypeWorkspaceView));
         Register(StringKey.From(AccountsContracts.BusinessPartnerSelector), typeof(BusinessPartnerSelectorView));
         Register(StringKey.From(AccountsContracts.BusinessPartnerWorkspace), typeof(BusinessPartnerWorkspaceView));
         Register(StringKey.From(AccountsContracts.ContactSelector), typeof(ContactSelectorView));
         Register(StringKey.From(AccountsContracts.ContactsWorkspace), typeof(ContactWorkspaceView));

         Register(StringKey.From(BaseDataContracts.BaseDataModule), typeof(BaseDataModuleView));
         Register(StringKey.From(BaseDataContracts.CountryWorkspace), typeof(CountryWorkspaceView));
         Register(StringKey.From(BaseDataContracts.AdressSelector), typeof(AdressSelectorView));
         Register(StringKey.From(BaseDataContracts.CountrySelector), typeof(CountrySelectorView));         
         Register(StringKey.From(BaseDataContracts.PermissionsWorkspace), typeof(PermissionsWorkspaceView));
         Register(StringKey.From(BaseDataContracts.PostalCodeWorkspace), typeof(PostalCodeWorkspaceView));
         Register(StringKey.From(BaseDataContracts.PostalCodeSelector), typeof(PostalCodeSelectorView));
         Register(StringKey.From(BaseDataContracts.TeamMemberWorkspace), typeof(TeamMemberWorkspaceView));
         Register(StringKey.From(BaseDataContracts.TeamMemberSelector), typeof(TeamMemberSelectorView));         
         Register(StringKey.From(BaseDataContracts.UserWorkspace), typeof(UserWorkspaceView));
         Register(StringKey.From(BaseDataContracts.UserSelector), typeof(UserSelectorView));
         Register(StringKey.From(BaseDataContracts.UserRoleDetailsEditor), typeof(UserRoleDetailsEditor));

         Register(StringKey.From(PurchasesContracts.PurchasesModule), typeof(PurchasesModuleView));
         Register(StringKey.From(PurchasesContracts.ProviderOrderWorkspace), typeof(ProviderOrderWorkspaceView));
         Register(StringKey.From(PurchasesContracts.ProviderQuoteWorkspace), typeof(ProviderQuoteWorkspaceView));

      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
