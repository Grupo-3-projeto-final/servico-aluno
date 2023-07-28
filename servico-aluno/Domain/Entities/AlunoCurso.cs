using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;

namespace servico_aluno.Domain.ModelViews
{
    public class AlunoCurso : Student
    {
        public CourseRequestDto Curso { get; set; }
    }
}