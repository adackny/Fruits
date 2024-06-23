using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Fruits.Api.Communication.Wrappers;

namespace Fruits.Api.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            ErrorOr.Error firstError = errors[0];

            switch (firstError.Type)
            {
                case ErrorType.Validation:
                    return BadRequest(new Response(firstError));
                case ErrorType.Conflict:
                    return Conflict(new Response(firstError));
                case ErrorType.NotFound:
                    return NotFound(new Response(firstError));
                case ErrorType.Unauthorized:
                    return Unauthorized(new Response(firstError));
                case ErrorType.Forbidden:
                    return StatusCode(StatusCodes.Status403Forbidden, new Response(firstError));
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response(firstError));
            }
        }
    }
}
