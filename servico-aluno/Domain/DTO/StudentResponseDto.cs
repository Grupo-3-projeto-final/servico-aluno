using System.ComponentModel.DataAnnotations;

namespace servico_aluno.Domain.DTO
{
    public class StudentResponseDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public int CourseId { get; set; }
    }
}
