using Accounts.Bootstrapper;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Services;
using BaseData.Bootstrapper;
using BusinessAppFramework.Domain;
using Search.Bootstrapper;

namespace MyBusinessApp.Bootstrapper.Services
{
   public class ModuleBootstrapperProviderService : IModuleBootstrapperProviderService
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public ModuleBootstrapperProviderService()
      {

      }

      #endregion

      #region Public Methods

      public List<IModuleBootstrapper> GetModules()
      {
         var modules = new List<IModuleBootstrapper>()
          {
            new BaseDataModuleBootstrapper(),
            new AccountsModuleBootstrapper()
          };

         return modules;
      }

      public List<ISearchModule> GetSearchModules()
      {
         var modules = new List<ISearchModule>()
          {
             new SearchModuleBootstrapper()
          };

         return modules;
      }

      public IModuleBootstrapper? GetModuleByKey(StringKey key)
      {
         var modules = GetModules();
         return modules.FirstOrDefault(m => m.GetModuleWorkspaceKey() != null && m.GetModuleWorkspaceKey().Equals(key));
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
