
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task3.Application;
using Task3.Application.Behaviors;
using Task3.Application.Interface;
using Task3.Application.Mapping;
using Task3.Infrastructure.Persistence;
using Task3.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// 1. Database
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TaskDb3>(options =>
    options.UseSqlServer(connectionString));

// 2. Application Services
builder.Services.AddScoped<IProductService, ProductService>();

// 4. FluentValidation
builder.Services.AddValidatorsFromAssembly(
    typeof(ApplicationAssemblyReference).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(ApplicationAssemblyReference).Assembly);
});


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ProductProfile>();
}, AppDomain.CurrentDomain.GetAssemblies());

// 6. Controllers
builder.Services.AddControllers();

// 7. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// 8. HTTP Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
