using FluentValidation;
using Fruits.Api;
using Fruits.Api.Middlewares;
using Fruits.Application;
using Fruits.Application.Commands;
using Fruits.Application.Validators;
using Fruits.Domain;
using Fruits.Domain.Models;
using Fruits.Domain.Repositories;
using Fruits.Domain.Validations;
using Fruits.Infra;
using Fruits.Infra.Contexts;
using Fruits.Infra.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

var connectionString = builder.Configuration.GetConnectionString("Sqlite")
    ?? "Data source=fruits.db";

builder.Services.AddInfraLayer(connectionString);

builder.Services.AddApplicationLayer();

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
