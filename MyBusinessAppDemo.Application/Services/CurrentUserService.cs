using BusinessAppFramework.Application.Services;
using Microsoft.AspNetCore.Http;
using MyBusinessApp.Contracts;
using System.Security.Claims;

namespace MyBusinessApp.Application.Services
{
   public class CurrentUserService : ICurrentUserService
   {
      private readonly IHttpContextAccessor _context;

      public int? UserId
      {
         get
         {
            var sub = _context.HttpContext?.User?.FindFirst(CustomClaims.InternalUserIdClaim)?.Value ?? throw new UnauthorizedAccessException("Missing sub");
            return int.TryParse(sub, out var userId) ? userId : null;
         }
      }

      public string AuthenticationProviderId =>
        _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
        ?? throw new UnauthorizedAccessException("Missing sub");

      public CurrentUserService(
         IHttpContextAccessor context)
      {
         _context = context;
      }
   }
}
