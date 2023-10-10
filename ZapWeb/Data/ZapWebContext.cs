using Microsoft.EntityFrameworkCore;

namespace ZapWeb.Data
{
    public class ZapWebContext : DbContext
    {
        public ZapWebContext(DbContextOptions options) : base(options)
        {
        }
    }
}