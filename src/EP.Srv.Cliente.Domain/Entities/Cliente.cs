namespace EP.Srv.Cliente.Domain.Entities
{
    public class Cliente : EntidadeBase
    {
        public string Cpf { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string NomeRazao { get; set; } = string.Empty;
        public string CodigoEmpresa { get; set; } = string.Empty;
        public string DataSituacao { get; set; } = string.Empty;

        public Empresa Empresa { get; set; }
    }
}
