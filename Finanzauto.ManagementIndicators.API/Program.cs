using Finanzauto.ManagementIndicators.API.Configurations;
using Finanzauto.ManagementIndicators.API.Contracts;
using Finanzauto.ManagementIndicators.API.Persistence;
using Finanzauto.ManagementIndicators.API.Repositories;
using Finanzauto.Utils.Auth.ApiKey;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Load appsettings.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.development.json", optional: true, reloadOnChange: true);
});

builder.Services.AddDbContext<GaviotaDataDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionString")
    ));

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

builder.Services.AddAuthServices(builder.Configuration);

//Configure cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
