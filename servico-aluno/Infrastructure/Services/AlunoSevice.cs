using AutoMapper;
using FluentValidation;
using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.ModelViews;
using servico_aluno.Domain.Validators;
using servico_aluno.Infrastructure.Repositories.Interfaces;
using servico_aluno.Infrastructure.Services.Interfaces;
using System.Net;

namespace servico_aluno.Infrastructure.Services;

public class AlunoSevice : IStudentService
{
    private readonly IStudentRepository _alunoRepository;
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;

    public AlunoSevice(IStudentRepository alunoRepository, IMapper mapper, ICourseService courseService)
    {
        _alunoRepository = alunoRepository;
        _mapper = mapper;
        _courseService = courseService;
    }

    public async Task<IEnumerable<StudentResponseDto>> BuscarAlunos()
    {
        return null;
    }
    public async Task<StudentResponseDto> BuscarAluno(int codigoAluno)
    {
        if (codigoAluno <= 0)
            throw new Exception();

        var aluno = await _alunoRepository.GetById(codigoAluno);

        //Criar logica para recuperar aluno
        return _mapper.Map<StudentResponseDto>(aluno);
    }
    public async Task<StudentResponseDto> SalvarAluno(StudentRequestDto alunoDto)
    {
        var aluno = _mapper.Map<Student>(alunoDto);

        var courseRequest = new CourseRequestDto
        {
            CourseId = alunoDto.CourseId,
            Name = alunoDto.CourseName
        };

        _courseService.Save(courseRequest);

        if (!aluno.ValidarCPF())
            throw new Exception("CPF inválido");

        var alunoResult = await _alunoRepository.Save(aluno);

        return _mapper.Map<StudentResponseDto>(alunoResult);
    }

    public async Task RealizarPagamentoBoleto(StudentStatusPaymentDto aluno)
    {
        await _alunoRepository.UpdateEnabledStudent(aluno.IdAluno);
    }

}

