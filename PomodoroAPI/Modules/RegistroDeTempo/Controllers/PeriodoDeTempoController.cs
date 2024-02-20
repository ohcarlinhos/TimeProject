using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.RegistroDeTempo.Services;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("/api/periodo-de-tempo")]
public class PeriodoDeTempoController(IPeriodoDeTempoServices periodoDeTempoServices) : ControllerBase
{
    // TODO: adicionar métodos de CRUD
}