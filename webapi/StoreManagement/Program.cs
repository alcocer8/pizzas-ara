using Microsoft.EntityFrameworkCore;
using StoreManagement.Repository;
using StoreManagement.Repository.impl;
using StoreManagement.Service;
using StoreManagement.Service.impl;
using StoreManagement.Models.entities;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;


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

var key = builder.Configuration.GetValue<string>("JwtSettings:Key");
var keyStr = Encoding.ASCII.GetBytes (key);

builder.Services.AddAuthentication (authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer (bearerOptions =>
{
    bearerOptions.RequireHttpsMetadata = false;
    bearerOptions.SaveToken = true;
    bearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey (keyStr)
    };
});


builder.Services.AddCors (options =>
{
    options.AddPolicy ("MY_CORS", policy =>
    {
        policy.AllowAnyOrigin ();
        policy.AllowAnyMethod ();
        policy.AllowAnyHeader ();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen (c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication ();
app.UseAuthorization();
app.UseCors ("MY_CORS");
app.MapControllers();

app.Run();
