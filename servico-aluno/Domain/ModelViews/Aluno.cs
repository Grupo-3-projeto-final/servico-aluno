using static System.Runtime.InteropServices.JavaScript.JSType;

namespace servico_aluno.Domain.ModelViews
{
    public class Aluno
    {
        public int CodigoAluno { get; set; }
        public string NomeAluno { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Date DataNascimento { get; set; }

    }
}
