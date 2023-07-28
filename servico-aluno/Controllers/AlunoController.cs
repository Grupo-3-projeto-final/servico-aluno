using IdentityGama.Filters;
using Microsoft.AspNetCore.Mvc;
using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.ModelViews;
using servico_aluno.Infrastructure.Services;
using servico_aluno.Infrastructure.Services.Interfaces;

namespace servico_aluno.Controllers;

[ApiController]
[Authentication]
[Route("[controller]")]
public class AlunoController : ControllerBase
{
    private readonly ILogger<AlunoController> _logger;
    private readonly IStudentService _alunoService;
    private readonly LoginService _loginService;
    public AlunoController(
        ILogger<AlunoController> logger,
        IStudentService alunoService,
        LoginService loginService)
    {
        _logger = logger;
        _alunoService = alunoService;
        _loginService = loginService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> BuscarAluno()
    {
        try
        {
            return Ok(await _alunoService.BuscarAlunos());
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> BuscarAluno(int id)
    {
        try
        {
            return Ok(await _alunoService.BuscarAluno(id));
        }
        catch(Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> SalvarAluno([FromBody] StudentRequestDto aluno)
    {
        try
        {
            var alunoCreated = await _alunoService.SalvarAluno(aluno);
            return CreatedAtAction(nameof(SalvarAluno), new { id = alunoCreated.StudentId }, alunoCreated);
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }
       

    }

    [HttpGet]
    [Route("teste")]
    public async Task<ActionResult<IEnumerable<Student>>> TesteLogin()
    {
        try
        {
            _loginService.login();
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
};