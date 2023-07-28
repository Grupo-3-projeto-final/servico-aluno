using Microsoft.AspNetCore.Mvc;
using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Enum;
using servico_aluno.Infrastructure.Services;
using servico_aluno.Infrastructure.Services.Interfaces;

namespace servico_aluno.Controllers;

[ApiController]
[Route("[controller]")]
public class PagamentoAlunoController : ControllerBase
{
    private readonly IBoletoAlunoService _boletoService;
    private readonly IStudentService _studentService;

    public PagamentoAlunoController(IBoletoAlunoService boletoService, IStudentService studentService)
    {
        _boletoService = boletoService;
        _studentService = studentService;
    }
    [HttpPost]
    [Route("{codigoAluno}")]
    public async Task<ActionResult<string>> GerarBoletoAluno(int codigoAluno, TipoPagamentoEnum tipoPagamento)
    {
        var result = await _boletoService.GerarBoletoAluno(codigoAluno, tipoPagamento);
        return Ok(result);
    }

    [HttpPost]
    [Route("atualizar-status")]
    public async Task<ActionResult> BaixarBoletoAluno(StudentStatusPaymentDto studentStatusPayment)
    {
        await _studentService.RealizarPagamentoBoleto(studentStatusPayment);
        return Ok();
    }
}
