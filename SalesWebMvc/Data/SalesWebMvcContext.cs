using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente{ get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialista> Especialista{ get; set; }
    }
}
