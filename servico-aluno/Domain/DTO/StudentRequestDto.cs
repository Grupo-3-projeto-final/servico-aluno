namespace servico_aluno.Domain.DTO
{
    public class StudentRequestDto
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
    }
}
