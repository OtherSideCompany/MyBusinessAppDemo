using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Application.Services;

namespace BaseData.Application.Services
{
   public class UserPermissionResolverService : IUserPermissionResolverService
   {
      #region Fields

      

      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public UserPermissionResolverService()
      {
         
      }

      #endregion

      #region Public Methods

      public async Task<bool> CanCreateAsync(string permissionKey, int userId)
      {
         return await Task.FromResult(true);
      }

      public async Task<bool> CanDeleteAsync(string permissionKey, int userId)
      {
         return await Task.FromResult(true);
      }

      public async Task<bool> CanAccessAsync(string permissionKey, int userId)
      {
         return await Task.FromResult(true);
      }

      public async Task<bool> CanAccessAllAsync(string[] permissionKeys, int userId)
      {
         return await Task.FromResult(true);
      }

      public async Task<bool> CanAccessAnyAsync(string[] permissionKeys, int userId)
      {
         return await Task.FromResult(true);
      }

      public async Task<bool> CanReadAsync(string permissionKey, int userId)
      {
         return await Task.FromResult(true);
      }

      public async Task<bool> CanUpdateAsync(string permissionKey, int userId)
      {
         return await Task.FromResult(true);
      }

      #endregion

      #region Private Methods


      #endregion
   }
}
