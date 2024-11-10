using System.Globalization;
using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices();      // Application katmanındaki tüm servisleri ekler

builder.Services.AddPersistenceServices(builder.Configuration);   // Persistence katmanındaki tüm servisleri ekler
builder.Services.AddHttpContextAccessor();

//builder.Services.AddDistributedMemoryCache(); // Distributed Cache için Memory Cache kullanılacak
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379"); // Redis Cache kullanılacak

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS politikasını tanımlıyoruz
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:5220/")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Set the default culture (varsayılan dil)
    var defaultCulture = new CultureInfo("tr-TR");

    // Set the supported cultures
    var supportedCultures = new List<CultureInfo>
    {
        defaultCulture,
        new CultureInfo("en-US"),
        new CultureInfo("en-GB"),
        new CultureInfo("de-DE"),
        new CultureInfo("es-ES"),
        new CultureInfo("ru-RU")

    };
    // Add supported cultures
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.ApplyCurrentCultureToResponseHeaders = true;
});

var app = builder.Build();

// Localization middleware
var requestLocalizationOptions = app.Services
    .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;

app.UseRequestLocalization(requestLocalizationOptions);
app.UseRequestLocalization();

// CORS politikasını burada uyguluyoruz
app.UseCors("AllowBlazorApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
        app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();