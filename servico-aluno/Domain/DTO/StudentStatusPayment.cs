namespace servico_aluno.Domain.DTO
{
    public struct StudentStatusPaymentDto
    {
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        public bool Pago { get; set; }
    }
}
