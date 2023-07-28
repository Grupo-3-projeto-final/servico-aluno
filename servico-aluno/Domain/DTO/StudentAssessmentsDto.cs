namespace servico_aluno.Domain.DTO
{
    public struct StudentAssessmentsDto
    {
        public int id_aluno { get; set; }
        public int id_curso { get; set; }
        public AssessmentsGradesDto avaliacaoNotas { get; set; }
    }
}
