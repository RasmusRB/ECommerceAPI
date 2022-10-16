using ECommerceAPI.DataContext;
using ECommerceAPI.Managers;
using ECommerceAPI.Models.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment Environment = builder.Environment;
IServiceCollection Services = builder.Services;

// Add services to the container.

builder.Services.AddDbContext<EDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Database") + $"Database={Configuration.GetConnectionString("DatabaseName")}"));

builder.Services.AddScoped<IProduct, ProductsManager>();

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
