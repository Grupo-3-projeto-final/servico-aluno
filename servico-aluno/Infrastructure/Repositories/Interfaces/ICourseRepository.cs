using servico_aluno.Domain.Entities;

namespace servico_aluno.Infrastructure.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> Save(Course course);
        Task<Course> GetById(int id);
    }
}
