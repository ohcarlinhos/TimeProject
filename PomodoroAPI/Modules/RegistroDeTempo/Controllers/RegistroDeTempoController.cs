using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("api/registro-de-tempo")]
public class RegistroDeTempoController : ControllerBase
{
    private readonly IRegistroDeTempoRepository _registroDeTempoRepository;

    public RegistroDeTempoController(IRegistroDeTempoRepository registroDeTempoRepository)
    {
        _registroDeTempoRepository = registroDeTempoRepository;
    }

    [HttpGet]
    public ActionResult<List<RegistroDeTempoModel>> Index(int page, int perPage = 12)
    {
        return Ok(_registroDeTempoRepository.Index(page, perPage));
    }

    [HttpPost]
    public async Task<ActionResult<RegistroDeTempoModel>> Create([FromBody] RegistroDeTempoModelView registro)
    {
        return Ok(await _registroDeTempoRepository.Create(registro));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoModel>> Update(int id, [FromBody] RegistroDeTempoModelView registro)
    {
        return Ok(await _registroDeTempoRepository.Update(id, registro));
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoModel>> Delete(int id)
    {
        return Ok(await _registroDeTempoRepository.Delete(id));
    }
}