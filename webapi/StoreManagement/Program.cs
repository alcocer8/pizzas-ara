using Microsoft.EntityFrameworkCore;
using StoreManagement.Repository;
using StoreManagement.Repository.impl;
using StoreManagement.Service;
using StoreManagement.Service.impl;
using StoreManagement.Models.entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PizzitasContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PizzitasDBConnection"));
});

// Add Controller
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();

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
