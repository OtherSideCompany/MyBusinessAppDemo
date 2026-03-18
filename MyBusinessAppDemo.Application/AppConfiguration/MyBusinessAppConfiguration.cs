using BusinessAppFramework.Application.AppConfiguration;
using BusinessAppFramework.Application.Services;

namespace MyBusinessApp.Application.AppConfiguration
{
   public class MyBusinessAppConfiguration : IAppConfiguration
   {
      #region Fields

      private IFileSerializationService _fileSerializationService;

      #endregion

      #region Properties

      public string ConfigFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppInfo.Name, "config.json");

      public bool RememberUserName { get; set; }
      public string UserLogin { get; set; }
      public string DatabaseName { get; set; }
      public string DatabaseServerName { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public MyBusinessAppConfiguration()
      {
         DatabaseName = AppInfo.Name;
         DatabaseServerName = "\\localhost\\SQLEXPRESS";
         UserLogin = "";
      }

      public MyBusinessAppConfiguration(IFileSerializationService fileSerializationService) : this()
      {
         _fileSerializationService = fileSerializationService;
      }

      #endregion

      #region Public Methods

      public void Load()
      {
         var tempConfig = _fileSerializationService.DeserializeFromFile(ConfigFilePath, typeof(MyBusinessAppConfiguration));

         foreach (var property in GetType().GetProperties())
         {
            if (property.CanWrite)
            {
               property.SetValue(this, property.GetValue(tempConfig));
            }
         }
      }

      public void Save()
      {
         _fileSerializationService.SerializeToFile(ConfigFilePath, this);
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
