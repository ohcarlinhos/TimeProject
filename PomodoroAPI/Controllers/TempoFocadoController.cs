using Microsoft.AspNetCore.Mvc;

namespace PomodoroAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TempoFocadoController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}