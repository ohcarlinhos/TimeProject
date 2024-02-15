using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("api/[controller]")]
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
        return Ok(_registroDeTempoRepository.Listar(page, perPage));
    }

    [HttpPost]
    public async Task<ActionResult<RegistroDeTempoModel>> Adicionar([FromBody] RegistroDeTempoModelView registro)
    {
        return Ok(await _registroDeTempoRepository.Adicionar(registro));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoModel>> Atualizar(int id, [FromBody] RegistroDeTempoModelView registro)
    {
        return Ok(await _registroDeTempoRepository.Atualizar(id, registro));
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoModel>> Apagar(int id)
    {
        return Ok(await _registroDeTempoRepository.Apagar(id));
    }
}