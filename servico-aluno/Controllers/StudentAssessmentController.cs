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
public class StudentAssessmentController : ControllerBase
{
    private readonly ILogger<StudentAssessmentController> _logger;
    private readonly StudentAssessmentService _studentAssessmentService;
    private readonly LoginService _loginService;
    public StudentAssessmentController(
        ILogger<StudentAssessmentController> logger,
        StudentAssessmentService studentAssessmentService,
        LoginService loginService)
    {
        _logger = logger;
        _studentAssessmentService = studentAssessmentService;
        _loginService = loginService;
    }


    [HttpGet]
    [Route("Calculo")]
    //[ProducesResponseType(typeof(Task<IEnumerable<Aluno>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
    //[ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Student>>> CalculateGrades(int id)
    {
        try
        {
            _studentAssessmentService.GetStudentAssessments(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
};