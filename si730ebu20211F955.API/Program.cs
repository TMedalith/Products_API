using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebu20211F955.API.Shared.Persistence.Contexts;
using si730ebu20211F955.API.Shared.Persistence.Repositories;
using si730ebu20211F955.API.Inventory.Domain.Repositories;
using si730ebu20211F955.API.Inventory.Domain.Services;
using si730ebu20211F955.API.Inventory.Mapping;
using si730ebu20211F955.API.Inventory.Persistence.Repositories;
using si730ebu20211F955.API.Inventory.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add Api Documentation Information
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Titulo API",
        Version = "v1",
        Description = "Titulo RESTful API"
    });
});


// Add Database Connection
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString ?? throw new InvalidOperationException())
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure CORS Service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


// Dependency Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();

var app = builder.Build();

app.UseAuthentication();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}


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