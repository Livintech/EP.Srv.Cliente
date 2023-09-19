namespace EP.Srv.Cliente.Domain
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public EntidadeBase()
        {
            CriadoEm = DateTime.Now;
        }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}
