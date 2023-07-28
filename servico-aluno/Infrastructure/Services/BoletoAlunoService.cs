using AutoMapper;
using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.Enum;
using servico_aluno.Domain.ModelViews;
using servico_aluno.Infrastructure.Services.Interfaces;
using servico_aluno.Util.Converter;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace servico_aluno.Infrastructure.Services
{
    public class BoletoAlunoService : IBoletoAlunoService
    {
        private readonly IStudentService _alunoService;
        private readonly IMapper _mapper;
        private readonly IConfigurationRoot _configuration;
        private readonly LoginService _loginService;

        public BoletoAlunoService(IStudentService alunoService,IMapper mapper, LoginService loginService)
        {
            _alunoService = alunoService;
            _mapper = mapper;
            _loginService = loginService;
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public async Task<string> GerarBoletoAluno(int codigoAluno, TipoPagamentoEnum tipoPagamento)
        {
            if (codigoAluno <= 0)
                throw new ArgumentException("O código do aluno informado é inválido");

            StudentResponseDto aluno = await _alunoService.BuscarAluno(codigoAluno);

            if (aluno == null)
                throw new ArgumentException("Não foi encontrado aluno com o código informado");

            CourseResponseDto curso = new CourseResponseDto(); // chamar a api que retorna dados do curso

            var token = await _loginService.login();

            dynamic request = new
            {
                idAluno = aluno.StudentId,
                nomeAluno = aluno.Name,
                cpfAluno = aluno.Cpf,
                idCurso = aluno.CourseId,
                valorCurso = 500,
                idTipoPagamento = (int)tipoPagamento
            };
            var jsonRequest = JsonSerializer.Serialize(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string url = $"{Environment.GetEnvironmentVariable("URLPagamentoService")}/pagamento/gerar-url";

            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;

            //string urlBoleto = "";//Chamar service de boleto para gerar boleto e retornar a URL

            //return urlBoleto;
        }

    }
}
