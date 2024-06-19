using ErrorOr;
using Fruits.Application;
using Fruits.Api.Communication.Parameters;
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
    public async Task<IActionResult> Create(CreateFruitCommand createFruitCommand)
    {
        ErrorOr<Fruit> result = await _sender.Send(createFruitCommand);

        return result.Match(
            fruit => Ok(new Response(fruit)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParameter paginationParams)
    {
        var getAllFruitsQuery = new GetAllFruitsQuery
        {
            PageNumber = paginationParams.PageNumber,
            PageSize = paginationParams.PageSize
        };

        ErrorOr<IEnumerable<Fruit>> result = await _sender.Send(getAllFruitsQuery);

        return result.Match(
            fruits => Ok(new PagedResponse(paginationParams.PageNumber, paginationParams.PageSize, fruits)),
            errors => Problem(errors)
        );
    }
}
