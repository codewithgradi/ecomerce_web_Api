namespace MyApp.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


public static class ServiceExtensions
{
  public static void ConfigurationSqlContext(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("DevDB"))
    );
  }

  public static void AuthConfigurations(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddScoped<ITokenService, TokenService>();
    services.AddControllers()
      .AddNewtonsoftJson(options =>
      {
        options.SerializerSettings
        .ReferenceLoopHandling =
        Newtonsoft.Json.
        ReferenceLoopHandling.Ignore;
      });

    //1
    services.AddIdentity<AppUser, IdentityRole>(options =>
    {
      options.Password.RequireDigit = true;
      options.Password.RequireLowercase = true;
      options.Password.RequireUppercase = true;
      options.Password.RequireNonAlphanumeric = true;
      options.Password.RequiredLength = 12;
    }).AddEntityFrameworkStores<AppDbContext>();
    //2
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme =
      options.DefaultChallengeScheme =
      options.DefaultForbidScheme =
      options.DefaultScheme =
      options.DefaultSignInScheme =
      options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
      System.Text.
      Encoding.UTF8
      .GetBytes
      (configuration["JWT:SigningKey"]))
      };
    });
  }
}

