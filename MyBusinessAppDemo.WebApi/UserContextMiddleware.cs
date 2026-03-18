using BusinessAppFramework.Application.Services;

namespace MyBusinessApp.WebApi
{
   public class UserContextMiddleware
   {
      private readonly RequestDelegate _next;

      public UserContextMiddleware(RequestDelegate next)
      {
         _next = next;
      }

      public async Task InvokeAsync(HttpContext httpContext, IUserContext userContext)
      {
         var user = httpContext.User;

         if (user.Identity?.IsAuthenticated == true)
         {
            userContext.Id = int.Parse(user?.FindFirst(CustomClaims.InternalUserIdClaim)?.Value ?? "0");
            userContext.UserName = user?.Identity?.Name ?? string.Empty;
         }

         await _next(httpContext);
      }
   }
}
