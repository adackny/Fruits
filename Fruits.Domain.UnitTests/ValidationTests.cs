using FluentValidation;
using Fruits.Domain.Models;
using Fruits.Domain.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Fruits.Domain.UnitTests;

public class ValidationTests
{
    private readonly IServiceCollection _services;

    public ValidationTests()
    {
        _services = new ServiceCollection();
        _services.AddScoped<IValidator<Fruit>, FruitsValidations>();
    }

    [Fact]
    public void CaducityLessThan3Days_ShoulsGiveError()
    {
        ServiceProvider serviceProvider = _services.BuildServiceProvider();

        var validator = serviceProvider.GetRequiredService<IValidator<Fruit>>();

        var referenceDate = DateOnly.FromDateTime(DateTime.Now);

        var fruit = new Fruit
        {
            Name = "La fruta",
            Caducity = referenceDate.AddDays(1),
            Colors = ["red", "green"],
        };

        var validationResult = validator.Validate(fruit);

        Assert.False(validationResult.IsValid);
        Assert.Equal(nameof(Fruit.Caducity),
            validationResult.Errors.FirstOrDefault()?.PropertyName);
    }
}