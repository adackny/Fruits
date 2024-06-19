using ErrorOr;
using Fruits.Application;
using Fruits.Application.Queries;
using Fruits.Api.Communication.Wrappers;
using Fruits.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fruits.Api.Controllers;

[Route("api/[controller]")]
public class FruitsController : ApiControllerBase
{
    private readonly ISender _sender;

    public FruitsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFruitCommand command)
    {
        ErrorOr<Fruit> result = await _sender.Send(command);

        return result.Match(
            fruit => Ok(new Response(fruit)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllFruitsQuery query)
    {
        var getAllFruitsQuery = new GetAllFruitsQuery
        {
            PageNumber = query.PageNumber,
            PageSize = query.PageSize
        };

        ErrorOr<IEnumerable<Fruit>> result = await _sender.Send(getAllFruitsQuery);

        return result.Match(
            fruits => Ok(new PagedResponse(query.PageNumber, query.PageSize, fruits)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetFruitByIdQuery { Id = id };
        ErrorOr<Fruit> result = await _sender.Send(query);

        return result.Match(
            fruit => Ok(new Response(fruit)),
            errors => Problem(errors)
        );
    }
}
