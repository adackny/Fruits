using Fruits.Api;
using Fruits.Application;
using Fruits.Domain;
using Fruits.Domain.Repositories;
using Fruits.Infra;
using Fruits.Infra.Contexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Fruits.Domain.Models;
using Fruits.Domain.Validations;
using Fruits.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.TypeInfoResolver = new PolymorphicTypeResolver();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");

builder.Services.AddDbContext<FruitsDbContext>(optionsBuilder =>
    optionsBuilder.UseSqlite("Data source=fruits.db"));

builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssemblies(
        typeof(IMediatRMarker).Assembly
    ));

builder.Services.AddScoped<IFruitsUnitOfWork, FruitsUnitOfWork>();
builder.Services.AddScoped<IFruitsRepository, FruitsRepository>();
builder.Services.AddScoped<FruitsService>();
builder.Services.AddScoped<IValidator<Fruit>, FruitsValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
