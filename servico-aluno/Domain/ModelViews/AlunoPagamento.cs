namespace servico_aluno.Domain.ModelViews
{
    public class AlunoPagamento : Aluno
    {
        public int CodigoTipoPagamento { get; set; }
        public float ValorCurso { get; set; }
    }
}
