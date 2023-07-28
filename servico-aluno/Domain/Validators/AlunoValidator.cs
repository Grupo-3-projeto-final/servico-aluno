using FluentValidation;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.ModelViews;
using servico_aluno.Infrastructure.Repositories.Interfaces;

namespace servico_aluno.Domain.Validators
{
    public class AlunoValidator : AbstractValidator<Student>
    {
        public AlunoValidator() 
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Favor informar o nome do aluno");

            RuleFor(x => x.Cpf)
                .MinimumLength(11)
                .WithMessage("O CPF deve conter 11 digitos")
                .NotEmpty()
                .WithMessage("Favor informar o CPF");

            RuleFor(x => x.CourseId)
                .NotNull()
                .NotEmpty()
                .LessThanOrEqualTo(0)
                .WithMessage("Informar o curso do aluno é obrigatório");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Favor informar o email do aluno");

        }
    }
}
