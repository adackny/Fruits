using FluentValidation;
using Fruits.Application.Commands;
using Fruits.Application.Validators;
using Fruits.Domain.Models;
using Fruits.Domain.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Fruits.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<FruitsService>();
        services.AddScoped<IValidator<Fruit>, FruitValidator>();

        services.AddScoped<IValidator<CreateFruitCommand>, CreateFruitValidator>();
        services.AddScoped<IValidator<UpdateFruitCommand>, UpdateFruitValidator>();

        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(typeof(IMediatRMarker).Assembly
        ));

        return services;
    }
}
