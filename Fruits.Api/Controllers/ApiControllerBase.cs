using Microsoft.AspNetCore.Mvc;
using Fruits.Application.Wrappers;
using ErrorOr;

namespace Fruits.Api.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            Error firstError = errors[0];

            switch (firstError.Type)
            {
                case ErrorType.Validation:
                    return BadRequest(new Response(firstError));
                default:
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        new Response(firstError));
            }
        }
    }
}
