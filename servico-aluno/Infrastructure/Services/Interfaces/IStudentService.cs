using servico_aluno.Domain.DTO;
using servico_aluno.Domain.ModelViews;

namespace servico_aluno.Infrastructure.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseDto>> BuscarAlunos();
        Task<StudentResponseDto> BuscarAluno(int codigoAluno);
        Task<StudentResponseDto> SalvarAluno(StudentRequestDto alunoDto);
        Task RealizarPagamentoBoleto(StudentStatusPaymentDto aluno);
    }
}
