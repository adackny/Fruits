using Microsoft.AspNetCore.Mvc;
using Fruits.Domain.Errors;
using Fruits.Application.Wrappers;

namespace Fruits.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(Error error)
        {
            int statusCode = 500;

            switch (error)
            {
                case ValidationError:
                    return BadRequest(new Response(error));
                default:
                    return Problem(statusCode: statusCode, title: error.Message);
            }
        }
    }
}
