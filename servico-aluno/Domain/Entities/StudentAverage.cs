namespace servico_aluno.Domain.Entities
{
    public class StudentAverage
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Average { get; set; }
        public bool Approved { get; set; }
    }
}
