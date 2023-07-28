using servico_aluno.Domain.Enum;

namespace servico_aluno.Domain.Entities
{
    public class StudentAssessment
    {
        public int AssessmentId { get; set; }  
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public int CourseId { get; set; }
        public AssessmentType AssessmentType { get; set; }
    }
}
