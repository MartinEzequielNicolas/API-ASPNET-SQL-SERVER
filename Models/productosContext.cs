using Microsoft.EntityFrameworkCore;

namespace app.Models
{
    public class productosContext : DbContext
    {

        

        public productosContext(DbContextOptions<productosContext> options ) : base(options)
        { 


        }

        public DbSet<Producto> Productos { get; set; }

    }
}
