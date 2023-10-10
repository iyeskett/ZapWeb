namespace ZapWeb.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public Grupo Grupo { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
        public string Texto { get; set; } = null!;
        public DateTime DataEnvio { get; set; }
    }
}