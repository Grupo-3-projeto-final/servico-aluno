using Microsoft.AspNetCore.Mvc;

namespace servico_aluno.Controllers;

[ApiController]
[Route("[controller]")]
public class BoletoController : ControllerBase
{
    private readonly ILogger<AlunoController> _logger;
    public BoletoController(ILogger<AlunoController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public int teste()
    {
        return 0;
    }
}
