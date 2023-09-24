namespace EP.Srv.Cliente.Domain.Entities
{
    public class PlanoContas : EntidadeBase
    {
        public string Codigo { get; set; } = string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string TipoNatureza { get; set; } = string.Empty;
        public string Natureza { get; set; } = string.Empty;
    }
}
