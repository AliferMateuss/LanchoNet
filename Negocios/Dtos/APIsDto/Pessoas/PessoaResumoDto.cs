namespace Negocios.Dtos.APIsDto.Pessoas
{
    public class PessoaResumoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public bool Cliente { get; set; }
        public bool Funcionario { get; set; }
        public bool Fornecedor { get; set; }
    }
}
