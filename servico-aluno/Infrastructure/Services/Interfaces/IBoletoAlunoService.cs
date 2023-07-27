using servico_aluno.Domain.Enum;

namespace servico_aluno.Infrastructure.Services.Interfaces
{
    public interface IBoletoAlunoService
    {
        Task<string> GerarBoletoAluno(int codigoAluno, TipoPagamentoEnum tipoPagamento);
        Task<bool> BaixarBoletoAluno(int codigoAluno);
    }
}
