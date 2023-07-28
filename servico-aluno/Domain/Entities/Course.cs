using System.ComponentModel.DataAnnotations;

namespace servico_aluno.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}