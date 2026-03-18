using BusinessAppFramework.Application.Services;
using BusinessAppFramework.Infrastructure.Services;
using MyBusinessApp.Bootstrapper.Services;
using MyBusinessApp.WebApi;
using System.Security.Claims;

const string _allowFrontendDev = "AllowFrontendDev";
//const string _localHost = "http://localhost:5173";

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

var bootstrapService = new BootstrapService();

BuildAppServices(bootstrapService, builder);
//BuildAuthenticationService(builder, env);

var mvcBuilder = builder.Services.AddControllers();
bootstrapService.RegisterControllers(mvcBuilder);

builder.Services.AddEndpointsApiExplorer();

AddCorsPolicy(env);

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "devuser"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim("role", "Admin"),
            new Claim("email", "anthony.thonon@other-side.be"),
            new Claim(CustomClaims.InternalUserIdClaim, "1")
        };

        var identity = new ClaimsIdentity(claims, "Development");
        context.User = new ClaimsPrincipal(identity);

        await next.Invoke();
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<UserContextMiddleware>();

UserCors(env, app);

await InitializeDatabaseAsync(app);

app.UseHttpsRedirection();

app.MapControllers();

//BuildDefaultEndpoints();

using (var scope = app.Services.CreateScope())
{
    bootstrapService.RegisterModules(scope.ServiceProvider);
    bootstrapService.RegisterTrees(scope.ServiceProvider);
    bootstrapService.RegisterLocalizedStrings(scope.ServiceProvider);
    bootstrapService.RegisterDocuments(scope.ServiceProvider);
}

app.Run();

void BuildAppServices(BootstrapService bootstrapService, WebApplicationBuilder builder)
{
    var appServices = bootstrapService.GetServices(builder.Configuration);

    foreach (var descriptor in appServices)
    {
        builder.Services.Add(descriptor);
    }
}

async Task InitializeDatabaseAsync(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializerService>();
        await dbInitializer.InitializeDatabaseAsync();
    }
}

void AddCorsPolicy(IWebHostEnvironment environment)
{
    if (environment.IsDevelopment())
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(_allowFrontendDev, policy =>
          {
               policy.WithOrigins("https://localhost:7285")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
           });
        });
    }
    else
    {
        throw new Exception("Production environment not handled");
    }
}

void UserCors(IWebHostEnvironment env, WebApplication app)
{
    if (env.IsDevelopment())
    {
        app.UseCors(_allowFrontendDev);
    }
    else
    {
        throw new Exception("Production environment not handled");
    }
}

/*void BuildDefaultEndpoints()
{
   app.MapGet("/me", (HttpContext ctx) =>
   {
      if (ctx.User?.Identity?.IsAuthenticated == true)
      {
         return Results.Ok(new
         {
            name = ctx.User.FindFirst("name")?.Value,
            sub = ctx.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
         });
      }
      return Results.Unauthorized();
   });

   app.MapGet("/login", (HttpContext ctx, IWebHostEnvironment env) =>
   {
      var redirect = env.IsDevelopment() ? _localHost : "/";
      var props = new AuthenticationProperties { RedirectUri = redirect };
      return Results.Challenge(props, new[] { "Auth0" });
   });

   app.MapGet("/logout", async (HttpContext ctx) =>
   {
      await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      await ctx.SignOutAsync("Auth0", new AuthenticationProperties { RedirectUri = "/" });
      return Results.Empty;
   });
}*/
