namespace ZapWeb.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public List<Usuario> Usuarios { get; set; } = null!;
    }
}