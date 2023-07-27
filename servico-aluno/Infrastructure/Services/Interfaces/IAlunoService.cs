using servico_aluno.Domain.ModelViews;

namespace servico_aluno.Infrastructure.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> BuscarAlunos();
        Task<Aluno> BuscarAluno(int codigoAluno);
        Task<bool> SalvarAluno(Aluno aluno);
        Task<bool> RealizarPagamentoBoleto(Aluno aluno);
    }
}
