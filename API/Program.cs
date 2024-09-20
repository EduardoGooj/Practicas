using System.Security.Principal;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, TokenService>();
var app = builder.Build();
// configure http request pipeline 
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200"));

app.MapControllers();

app.Run();
