using Microsoft.EntityFrameworkCore;
using ZapWeb.Models;

namespace ZapWeb.Data
{
    public class ZapWebContext : DbContext
    {
        public ZapWebContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}