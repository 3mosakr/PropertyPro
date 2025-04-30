using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PropertyPro.Api.Extentions;
using PropertyPro.Api.Middleware;
using PropertyPro.Data.Models;
using PropertyPro.Infrastructure;
using PropertyPro.Infrastructure.Data;
using PropertyPro.Service;
using PropertyPro.Service.Helper;
using Serilog;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connection to Database Server (Sql) using Connection string
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

#region Dependecies injection
// Add all modules dependacies 
builder.Services.AddInfrastructureDependecies()
                .AddServiceDependecies()
                .AddServiceRegisteration();
//.AddServiceRegisteration();
#endregion

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
);


// Add Bearer Authentication
var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JWT>();
builder.Services.AddSingleton(jwtOptions);
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });

builder.Services.AddCors();
//builder.Services.AddCors(options =>
//    options.AddDefaultPolicy(builder =>
//        builder
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .WithOrigins("https://localhost:7286")
//            .AllowCredentials()
//    )
//);


//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenJwtAuth();


// Configure Serilog to write logs to daily files
Log.Logger = new LoggerConfiguration()
    //.MinimumLevel.Debug() // تحديد مستوى اللوجز
    //.Enrich.FromLogContext() // إضافة معلومات إضافية
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day,
             outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}") // تخصيص تنسيق الفايل
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
// Make swager work in production and development
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseCors();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.UseStaticFiles();

app.Run();
