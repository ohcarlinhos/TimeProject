using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TimeProject.Api.Infrastructure.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult HandleError()
    {
        return Problem();
    }

    [Route("/error-development")]
    public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
            return NotFound();

        var exceptionHandleFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        return Problem(
            title: exceptionHandleFeature.Error.Message,
            detail: exceptionHandleFeature.Error.StackTrace
        );
    }
}