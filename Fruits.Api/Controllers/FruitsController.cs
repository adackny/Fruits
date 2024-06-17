using Fruits.Application;
using Fruits.Application.Wrappers;
using Fruits.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fruits.Api.Controllers;

[Route("[controller]")]
public class FruitsController : ApiController
{
    private readonly ISender _sender;

    public FruitsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFruitCommand fruit)
    {
        var createResult = await _sender.Send(fruit);

        return createResult.Match<IActionResult>(
            fruit => Ok(new Response(fruit)),
            err => Problem(err)
        );
    }
}
