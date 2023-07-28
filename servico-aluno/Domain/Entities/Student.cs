using System.ComponentModel.DataAnnotations;

namespace servico_aluno.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(11)]
        public string Cpf { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

        [Required]
        public int CourseId { get; set; }

        public bool Enabled { get; set; }

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
