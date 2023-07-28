using Microsoft.Extensions.Options;
using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.Enum;
using servico_aluno.Domain.Queue.Producer;
using servico_aluno.Infrastructure.Repositories;
using System.Text.Json;

namespace servico_aluno.Infrastructure.Services
{
    public class StudentAverageService
    {
        private readonly StudentAverageRepository _repository;
        private readonly SqsProducerService _producerAws;

        public StudentAverageService(StudentAverageRepository repository, SqsProducerService producer)
        {
            _repository = repository;
            _producerAws = producer;
        }

        public async Task ProcessarMensagemAsync(string body)
        {
            StudentAverage student = JsonSerializer.Deserialize<StudentAverage>(body);
            var result = _repository.Save(student);
        }
    }
}
