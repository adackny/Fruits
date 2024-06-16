using System.Diagnostics;
using Fruits.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fruits.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FruitsController : ControllerBase
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
                fruit => Ok(fruit),
                err => err.ErrorCode switch
                {
                    "err-invalid-domain" => BadRequest(err),
                    _ => throw new UnreachableException(),
                }
            );
    }
}
