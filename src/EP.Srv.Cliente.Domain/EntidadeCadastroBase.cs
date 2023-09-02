
using System.ComponentModel.DataAnnotations;

namespace EP.Srv.Cliente.Domain
{
    public class EntidadeCadastroBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CriadoEm { get; private set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public EntidadeCadastroBase()
        {
            CriadoEm = DateTime.Now;
        }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}
