namespace EP.Srv.Cliente.Domain.Entities
{
    public class ContasPagar : EntidadeBase
    {
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string NumeroTitulo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public DateTime Vencimento { get; set; }
        public DateTime DtEmissao { get; set; }
        public DateTime DtLancamento { get; set; }

        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
    }
}
