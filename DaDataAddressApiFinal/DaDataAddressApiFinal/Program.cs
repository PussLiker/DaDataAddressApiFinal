using Serilog;
using DaDataAddressApiFinal.Mapping;
using DaDataAddressApiFinal.Middleware;
using DaDataAddressApiFinal.Models;
using Microsoft.AspNetCore.Builder;
using DaDataAddressApiFinal.Clients;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);


// serilog
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();

//  swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//  mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<DaDataOptions>(
    builder.Configuration.GetSection("DaData"));

// DI
builder.Services.AddHttpClient<ICleanAddressClient, DaDataCleanClient>();


// cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().
        AllowAnyMethod().
        AllowAnyHeader();
        });

});


var app = builder.Build();

//включаем cors
app.UseCors();

// подключаем swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// подключение middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
