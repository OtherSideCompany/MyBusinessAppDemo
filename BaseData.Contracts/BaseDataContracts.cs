namespace BaseData.Contracts
{
   public class BaseDataContracts
   {
      #region Fields



      #endregion

      #region Properties

      public static string BaseDataModule = "basedata";
      public static string CompanyBrowserWorkspace = "companies";
      public static string CountryBrowserWorkspace = "countries";
      public static string DocumentBrowserWorkspace = "documents";
      public static string PostalCodeBrowserWorkspace = "postal-codes";

      public static string AdressSelector = "adress.selector";
      public static string CountrySelector = "countries.selector";
      public static string PostalCodeSelector = "postal-codes.selector";
      public static string TeamMemberSelector = "team-members.selector";

      public static string AdressEditor = "BaseData.AdressEditor";
      public static string CountryEditor = "BaseData.CountryEditor";
      public static string NoteEditor = "BaseData.NoteEditor";
      public static string PostalCodeEditor = "BaseData.PostalCodeEditor";

      public const string AdressPermissionKey = "BaseData.AdressPermissionKey";
      public const string CompanyPermissionKey = "BaseData.CompanyPermissionKey";
      public const string CountryPermissionKey = "BaseData.CountryPermissionKey";
      public const string DocumentPermissionKey = "BaseData.DocumentPermissionKey";
      public const string NotePermissionKey = "BaseData.NotePermissionKey";
      public const string PostalCodePermissionKey = "BaseData.PostalCodePermissionKey";

      public const string PostalCodeCountryReference = "BaseData.PostalCodeCountryReference";
      public const string AdressPostalCodeReference = "BaseData.AdressPostalCodeReference";
      public const string NoteUserReference = "BaseData.NoteUserReference";

      public const string Adress_ParentName = "Adress_ParentName";
      public const string Adress_Label = "Adress_Label";
      public const string Adress_AdressDescription = "Adress_AdressDescription";
      public const string Adress_City = "Adress_City";
      public const string Adress_PostalCodeReference = "Adress_PostalCodeReference";
      public const string Adress_CountryAlpha2Code = "Adress_CountryAlpha2Code";

      public const string Company_Name = "Company_Name";
      public const string Company_VatNumber = "Company_VatNumber";
      public const string Company_WebsiteUrl = "Company_WebsiteUrl";
      public const string Company_Phone = "Company_Phone";

      public const string Country_Name = "Country_Name";
      public const string Country_Alpha2Code = "Country_Alpha2Code";
      public const string Country_Alpha3Code = "Country_Alpha3Code";
      public const string Country_NumericCode = "Country_NumericCode";

      public const string Document_FileName = "Document_FileName";
      public const string Document_ContentType = "Document_ContentType";
      public const string Document_Size = "Document_Size";
      public const string Document_CreatedByName = "Document_CreatedByName";

      public const string Note_Text = "Note_Text";

      public const string PostalCode_Code = "PostalCode_Code";
      public const string PostalCode_City = "PostalCode_City";
      public const string PostalCode_CountryReference = "PostalCode_CountryReference";    

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BaseDataContracts()
      {

      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
