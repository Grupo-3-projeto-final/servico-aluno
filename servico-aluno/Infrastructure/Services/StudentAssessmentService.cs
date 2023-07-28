using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.Enum;
using servico_aluno.Domain.Queue.Producer;
using servico_aluno.Infrastructure.Repositories;
using System.Text.Json;

namespace servico_aluno.Infrastructure.Services
{
    public class StudentAssessmentService
    {
        private readonly StudentAssessmentRepository _repository;
        private readonly SqsProducerService _producerAws;

        public StudentAssessmentService(StudentAssessmentRepository repository, SqsProducerService producer)
        {
            _repository = repository;
            _producerAws = producer;
        }

        public async Task<List<StudentAssessment>> GetStudentAssessments(int id)
        {
            var listGradeStudent = await _repository.GetById(id);

            var teste = new StudentAssessmentsDto
            {
                id_aluno = listGradeStudent.FirstOrDefault().StudentId,
                id_curso = listGradeStudent.FirstOrDefault().CourseId,
                avaliacaoNotas = new AssessmentsGradesDto
                {
                    notaA1 = listGradeStudent.FirstOrDefault(n => n.AssessmentType == AssessmentType.A1).Grade,
                    notaA2 = listGradeStudent.FirstOrDefault(n => n.AssessmentType == AssessmentType.A2).Grade,
                    notaA3 = listGradeStudent.FirstOrDefault(n => n.AssessmentType == AssessmentType.A3).Grade,
                }
            };
            var testeJson = JsonSerializer.Serialize(teste);
            _producerAws.SendAsync(testeJson);


            return new List<StudentAssessment>();
        }
    }
}
