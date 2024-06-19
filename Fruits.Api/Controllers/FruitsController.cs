using ErrorOr;
using Fruits.Application;
using Fruits.Application.Queries;
using Fruits.Application.Wrappers;
using Fruits.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fruits.Api.Controllers;

[Route("[controller]")]
public class FruitsController : ApiControllerBase
{
    private readonly ISender _sender;

    public FruitsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFruitCommand createFruitCommand)
    {
        ErrorOr<Fruit> result = await _sender.Send(createFruitCommand);

        return result.Match<IActionResult>(
            fruit => Ok(new Response(fruit)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getFruitsQuery = new GetFruitsQuery();
        ErrorOr<IEnumerable<Fruit>> result = await _sender.Send(getFruitsQuery);

        return result.Match<IActionResult>(
            fruits => Ok(new Response(fruits)),
            errors => Problem(errors)
        );
    }
}
