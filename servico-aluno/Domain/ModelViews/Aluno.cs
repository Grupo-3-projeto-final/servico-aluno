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
        public int CodigoCurso { get; set; }
        public bool PagamentoRealizado { get; set; }

        public bool ValidarCPF()
        {
            Cpf = Cpf.Replace(".", "").Replace("-", "");

            if (Cpf.Length != 11)
            {
                return false;
            }

            bool todosDigitosIguais = true;
            for (int i = 1; i < 11; i++)
            {
                if (Cpf[i] != Cpf[0])
                {
                    todosDigitosIguais = false;
                    break;
                }
            }

            if (todosDigitosIguais)
            {
                return false;
            }

            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(Cpf[i].ToString()) * (10 - i);
            }

            int resto = soma % 11;
            int primeiroDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(Cpf[9].ToString()) != primeiroDigitoVerificador)
            {
                return false;
            }

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(Cpf[i].ToString()) * (11 - i);
            }

            resto = soma % 11;
            int segundoDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(Cpf[10].ToString()) != segundoDigitoVerificador)
            {
                return false;
            }

            return true;
        }
    }
}
