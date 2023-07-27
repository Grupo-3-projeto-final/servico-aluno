using AutoMapper;
using FluentValidation;
using servico_aluno.Domain.ModelViews;
using servico_aluno.Domain.Validators;
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

    public async Task<IEnumerable<Aluno>> BuscarAlunos()
    {
        return null;
    }
    public async Task<Aluno> BuscarAluno(int codigoAluno)
    {
        if (codigoAluno <= 0)
            throw new Exception("Codigo do aluno informado inexistente");

        Aluno aluno = new Aluno();

        //Criar logica para recuperar aluno
        return aluno;
    }
    public async Task<bool> SalvarAluno(Aluno aluno)
    {
        if (!aluno.ValidarCPF())
            throw new Exception("CPF inválido");

        new AlunoValidator().Validate(aluno,
            Erros =>
        {
            throw new Exception("Parâmetro informado incorretamente. Mensagem: " + Erros.ToString());
        });

        //chamar o metodo repositorio para salvar o aluno no banco

        return true;
    }
    public void DeletarAlunoPorId()
    {

    }

    public async Task<bool> RealizarPagamentoBoleto(Aluno aluno)
    {
        if (aluno == null)
            throw new Exception("CPF inválido");

        //Chamar metodo repositorio para realizar update do aluno para pago

        return true;
    }
}

