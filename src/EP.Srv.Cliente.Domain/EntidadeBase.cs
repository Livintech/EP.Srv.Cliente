namespace EP.Srv.Cliente.Domain
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; private set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}
