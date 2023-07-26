using Microsoft.AspNetCore.Mvc;
using servico_aluno.Domain.ModelViews;
using servico_aluno.Infrastructure.Services;
using servico_aluno.Infrastructure.Services.Interfaces;

namespace servico_aluno.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunoController : ControllerBase
{
    private readonly ILogger<AlunoController> _logger;
    private readonly IAlunoService _alunoService;
    public AlunoController(
        ILogger<AlunoController> logger,
        IAlunoService alunoService)
    {
        _logger = logger;
        _alunoService = alunoService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Task<IEnumerable<Aluno>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Aluno>>> BuscarAluno()
    {
        return Ok(await _alunoService.BuscaAlunos());
    }

    [HttpGet]
    [Route("{codigoAluno}")]
    [ProducesResponseType(typeof(Aluno), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public int BuscarAlunoPorCodigo(int codigoAluno)
    {
        return 0;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public void SalvarAluno()
    {

    }
    [HttpDelete]
    [Route("codigoAluno")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public void DeletarAlunoPorCodigo()
    {

    }
};