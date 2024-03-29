﻿namespace EP.Srv.Cliente.Domain.Entities
{
    public class Empresa : EntidadeBase
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
        public string DataSituacao { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;

        public IEnumerable<Banco> Bancos { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<FormaPagamento> FormaPagamentos { get; set; }
        public IEnumerable<CentroCustos> CentroCustos { get; set; }
        public IEnumerable<ProdutosServicos> ProdutosServicos { get; set; }
        public IEnumerable<ContasPagar> ContasPagar { get; set; }
    }
}
