using API.Extensions;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(
    configuration =>
    {
        // No configuration needed yet.
    }, 
    typeof(ServiceAssembly));
builder.Services
    .AddApplicationRepositories()
    .AddApplicationServices();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:4200", "https://localhost:4200");
});
app.MapControllers();

app.Run();

