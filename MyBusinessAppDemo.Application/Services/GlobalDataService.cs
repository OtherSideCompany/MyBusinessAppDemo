using BusinessAppFramework.Application.Services;

namespace MyBusinessApp.Application.Services
{
   public class GlobalDataService : IGlobalDataService
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public GlobalDataService()
      {

      }


      #endregion

      #region Public Methods

      public async Task LoadGlobalDataAsync()
      {
         await Task.CompletedTask;
      }

      public void UnloadData()
      {

      }

      #endregion

      #region Private Methods



      #endregion
   }
}
