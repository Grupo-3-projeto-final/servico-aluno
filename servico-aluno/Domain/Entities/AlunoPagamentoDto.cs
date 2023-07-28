using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;

namespace servico_aluno.Domain.ModelViews
{
    public class AlunoPagamentoDto : StudentResponseDto
    {
        public int CodigoTipoPagamento { get; set; }
        public double ValorCurso { get; set; }
    }
}
