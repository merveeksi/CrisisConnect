using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices();      // Application katmanındaki tüm servisleri ekler

builder.Services.AddPersistenceServices(builder.Configuration);   // Persistence katmanındaki tüm servisleri ekler
builder.Services.AddHttpContextAccessor();

//builder.Services.AddDistributedMemoryCache(); // Distributed Cache için Memory Cache kullanılacak
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "loclhost:6379"); // Redis Cache kullanılacak

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

// CORS politikasını burada uyguluyoruz
app.UseCors("AllowBlazorApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if(app.Environment.IsProduction())
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();