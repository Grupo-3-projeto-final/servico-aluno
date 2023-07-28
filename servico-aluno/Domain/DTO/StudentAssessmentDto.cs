using servico_aluno.Domain.Enum;

namespace servico_aluno.Domain.DTO
{
    public struct StudentAssessmentDto
    {
        public int AssessmentId { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public AssessmentType AssessmentType { get; set; }

    }
}
