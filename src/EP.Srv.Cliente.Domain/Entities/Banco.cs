namespace EP.Srv.Cliente.Domain.Entities
{
    public class Banco : EntidadeBase
    {
        public int Codigo { get; set; }
        public string Instituicao { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public int Conta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public DateTime DataSaldoInicio { get; set; }

        public Empresa Empresa { get; set; } = new();
        public int EmpresaId { get; set; }
    }
}
