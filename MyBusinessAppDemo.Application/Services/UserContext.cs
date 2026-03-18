using BusinessAppFramework.Application.Services;

namespace MyBusinessApp.Application.Services
{
   public class UserContext : IUserContext
   {
      #region Fields



      #endregion

      #region Properties

      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string UserName { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public UserContext()
      {

      }

      public string GetName()
      {
         if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
         {
            return FirstName + " " + LastName;
         }
         else
         {
            return UserName;
         }
      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
