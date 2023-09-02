namespace EP.Srv.Cliente.Domain.Models
{
    public class FileModel
    {
        public string? NomeArquivo { get; set; }
        public string? Tamano { get; set; }
        public string? Extensao { get; set; }
        public string? Data { get; set; }
        public byte[] Arquivo { get; set; }
    }
}
