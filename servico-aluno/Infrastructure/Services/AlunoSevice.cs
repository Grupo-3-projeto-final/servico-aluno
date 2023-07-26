using servico_aluno.Domain.ModelViews;
using servico_aluno.Infrastructure.Repositories.Interfaces;
using servico_aluno.Infrastructure.Services.Interfaces;

namespace servico_aluno.Infrastructure.Services;

public class AlunoSevice : IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoSevice(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<IEnumerable<Aluno>> BuscaAlunos()
    {
        return null;
    }
    public async Task<Aluno> BuscaAlunoPorId(int codigoAluno)
    {
        return null;
    }
    public void DeletarAlunoPorId()
    {

    }
}

