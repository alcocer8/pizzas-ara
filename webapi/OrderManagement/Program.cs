using Microsoft.EntityFrameworkCore;
using OrderManagement.Repository;
using OrderManagement.Repository.impl;
using OrderManagement.Service;
using OrderManagement.Service.impl;
using OrderManagement.Models.entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzitasContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PizzitasDBConnection"));
});

// Add Controller
builder.Services.AddScoped<IOrderRepository, OrdenRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

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
