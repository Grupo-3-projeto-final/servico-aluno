using AutoMapper;
using servico_aluno.Domain.Enum;
using servico_aluno.Domain.ModelViews;
using servico_aluno.Infrastructure.Services.Interfaces;

namespace servico_aluno.Infrastructure.Services
{
    public class BoletoAlunoService : IBoletoAlunoService
    {
        private readonly IAlunoService _alunoService;
        private readonly IMapper _mapper;

        public BoletoAlunoService(IAlunoService alunoService,IMapper mapper)
        {
            _alunoService = alunoService;
            _mapper = mapper;
        }
        public async Task<string> GerarBoletoAluno(int codigoAluno, TipoPagamentoEnum tipoPagamento)
        {
            if (codigoAluno <= 0)
                throw new ArgumentException("O código do aluno informado é inválido");

            Aluno aluno = await _alunoService.BuscarAluno(codigoAluno);

            if (aluno == null)
                throw new ArgumentException("Não foi encontrado aluno com o código informado");

            AlunoPagamento alunoPagamento = _mapper.Map<AlunoPagamento>(aluno);

            Curso curso = new Curso(); // chamar a api que retorna dados do curso

            alunoPagamento.PagamentoRealizado = true;
            alunoPagamento.ValorCurso = curso.ValorCurso;

            //Todos os dados que preciso para gerar o boleto estao no aluno pagamento, basta chamar a api do serviço de boleto, passando os dados

            string urlBoleto = "";//Chamar service de boleto para gerar boleto e retornar a URL

            return urlBoleto;
        }
        public async Task<bool> BaixarBoletoAluno(int codigoAluno)
        {
            if (codigoAluno <= 0)
                throw new ArgumentException("O código do aluno informado é inválido");

            Aluno aluno = await _alunoService.BuscarAluno(codigoAluno);

            if (aluno == null)
                throw new ArgumentException("Não foi encontrado aluno com o código informado");

            


            //Chamar service de boleto para gerar boleto e retornar a URL do boleto

            return true;
        }
    }
}
