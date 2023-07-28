using servico_aluno.Domain.Entities;

namespace servico_aluno.Infrastructure.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> Save(Student aluno);
        Task<Student> GetById(int id);
        Task<List<Student>> GetAll();
        Task UpdateEnabledStudent(int id);

    }
}
