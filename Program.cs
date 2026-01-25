using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using MyApp.Extensions;
using System.IdentityModel.Tokens.Jwt;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.ConfigurationSqlContext(builder.Configuration);
builder.Services.AuthConfigurations(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

