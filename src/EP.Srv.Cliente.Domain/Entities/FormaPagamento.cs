namespace EP.Srv.Cliente.Domain.Entities
{
    public class FormaPagamento : EntidadeBase
    {
        public string Descricao { get; set; } = string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;

        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
    }
}
