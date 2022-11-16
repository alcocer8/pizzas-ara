using DetallesOrdenManagement.Models.entities;
using DetallesOrdenManagement.Service.impl;
using DetallesOrdenManagement.Service;
using DetallesOrdenManagement.Repository;
using DetallesOrdenManagement.Repository.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzitasContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PizzitasDBConnection"));
});


builder.Services.AddScoped<IDetallesOrdenRepository, DetallesOrdenRepository>();
builder.Services.AddScoped<IDetallesOrdenService, DetallesOrdenService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
