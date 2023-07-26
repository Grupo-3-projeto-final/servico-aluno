using servico_aluno.Domain.ModelViews;

namespace servico_aluno.Infrastructure.Services.Interfaces
{
    public interface IAlunoService
    {
        public Task<IEnumerable<Aluno>> BuscaAlunos();
        public Task<Aluno> BuscaAlunoPorId(int codigoAluno);
    }
}
