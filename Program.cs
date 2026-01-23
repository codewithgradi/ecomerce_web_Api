using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Database configurations
var connectionString = builder.Configuration.GetConnectionString("DevDB");
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(connectionString)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();

