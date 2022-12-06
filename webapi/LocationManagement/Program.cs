using LocationManagement.Models;
using LocationManagement.Services;
using LocationManagement.Services.implementation;
using LocationManagement.Repositories;
using LocationManagement.Repositories.implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DB Context
builder.Services.AddDbContext<PizzitasContext>(options => 
{
    var connectionString = configuration.GetConnectionString("pizzitasConnection");
    options.UseNpgsql(connectionString);
});

// Services
builder.Services.AddScoped<ICiudadService, CiudadService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IMunicipioService, MunicipioService>();
// Repositories
builder.Services.AddScoped<ICiudadRepository, CiudadRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
