using pizzitas_web.Models.entities;
using pizzitas_web.Services.impl;
using pizzitas_web.Services;
using pizzitas_web.Repositories;
using pizzitas_web.Repositories.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add DB Context
builder.Services.AddDbContext<pizzitasContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PizzitasDBConnection"));
});


builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

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
