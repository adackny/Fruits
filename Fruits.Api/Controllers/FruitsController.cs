using ErrorOr;
using Fruits.Application;
using Fruits.Application.Queries;
using Fruits.Api.Communication.Wrappers;
using Fruits.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Fruits.Application.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Fruits.Api.Errors;

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

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateFruitCommand command)
    {
        if (id != command.Id)
        {
            var error = CommonError.IdMismatch;

            return Problem([error]);
        }

        ErrorOr<Fruit?> result = await _sender.Send(command);

        return result.Match(
            fruit => Ok(new Response(fruit!)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllFruitsQuery query)
    {
        ErrorOr<IEnumerable<Fruit>> result = await _sender.Send(query);

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
