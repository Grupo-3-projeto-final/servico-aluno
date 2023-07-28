using servico_aluno.Domain.DTO;

namespace servico_aluno.Infrastructure.Services.Interfaces
{
    public interface ICourseService
    {
        Task<bool> Save(CourseRequestDto courseDto);
    }
}
