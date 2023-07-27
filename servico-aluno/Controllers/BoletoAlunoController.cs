using Microsoft.AspNetCore.Mvc;
using servico_aluno.Domain.Enum;
using servico_aluno.Infrastructure.Services;
using servico_aluno.Infrastructure.Services.Interfaces;

namespace servico_aluno.Controllers;

[ApiController]
[Route("[controller]")]
public class BoletoAlunoController : ControllerBase
{
    private readonly IBoletoAlunoService _boletoService;

    public BoletoAlunoController(IBoletoAlunoService boletoService)
    {
        _boletoService = boletoService;
    }
    [HttpPost]
    [Route("{codigoAluno}")]
    [ProducesResponseType(typeof(Task<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<string>> GerarBoletoAluno(int codigoAluno, TipoPagamentoEnum tipoPagamento)
    {
        return Ok(_boletoService.GerarBoletoAluno(codigoAluno, tipoPagamento));
    }

    [HttpPost]
    [Route("BaixarBoleto/{CodigoAluno}")]
    [ProducesResponseType(typeof(Task<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<string>> BaixarBoletoAluno(int codigoAluno)
    {
        return Ok(_boletoService.BaixarBoletoAluno(codigoAluno));
    }
}
