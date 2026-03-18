namespace Accounts.Contracts
{
   public class AccountsContracts
   {
      public static string AccountsModule = "accounts";
      public static string BusinessPartnerTypeWorkspace = "business-partner-types";
      public static string BusinessPartnerWorkspace = "business-partners";
      public static string ContactsWorkspace = "contacts";

      public static string BusinessPartnerEditor = "Accounts.BusinessPartnerEditor";
      public static string BusinessPartnerTypeEditor = "Accounts.BusinessPartnerTypeEditor";
      public static string ContactEditor = "Accounts.ContactEditor";

      public static string BusinessPartnerSelector = "Accounts.BusinessPartnerSelector";
      public static string BusinessPartnerTypeSelector = "Accounts.BusinessPartnerTypeSelector";
      public static string ContactSelector = "Accounts.ContactSelector";

      public static string BusinessPartnerAdressTree = "Accounts.BusinessPartnerAdressTree";
      public static string BusinessPartnerContactTree = "Accounts.BusinessPartnerContactTree";
      public static string BusinessPartnerNoteTree = "Accounts.BusinessPartnerNoteTree";

      public const string BusinessPartnerPermissionKey = "Accounts.BusinessPartnerPermissionKey";
      public const string BusinessPartnerTypePermissionKey = "Accounts.BusinessPartnerTypePermissionKey";
      public const string ContactPermissionKey = "Accounts.ContactPermissionKey";

      public const string BusinessPartnerBusinessPartnerTypeReference = "Accounts.BusinessPartnerBusinessPartnerTypeReference";
      public const string ContactBusinessPartnerReference = "Accounts.ContactBusinessPartnerReference";

      public const string BusinessPartner_Name = "BusinessPartner_Name";
      public const string BusinessPartner_VatNumber = "BusinessPartner_VatNumber";
      public const string BusinessPartner_BusinessPartnerTypeName = "BusinessPartner_BusinessPartnerTypeName";
      public const string BusinessPartner_ClientNumber = "BusinessPartner_ClientNumber";
      public const string BusinessPartner_ProviderNumber = "BusinessPartner_ProviderNumber";
      public const string BusinessPartner_BusinessPartnerTypesReferences = "BusinessPartner_BusinessPartnerTypesReferences";

      public const string BusinessPartnerType_Name = "BusinessPartnerType_Name";

      public const string Contact_Name = "Contact_Name";
      public const string Contact_ParentName = "Contact_ParentName";
      public const string Contact_IsActive = "Contact_IsActive";
      public const string Contact_Phone = "Contact_Phone";
      public const string Contact_Mail = "Contact_Mail";
      public const string Contact_BusinessPartnerReference = "Contact_BusinessPartnerReference";
   }
}
