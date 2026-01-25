using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using MyApp.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.ConfigurationSqlContext(builder.Configuration);
builder.Services.AuthConfigurations(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();

