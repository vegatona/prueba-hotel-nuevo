using Microsoft.EntityFrameworkCore;
using pruebahotel.Data.Models;

namespace pruebahotel.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Habitacion> habitaciones { get ;set; }
        public DbSet<reservaciones> Reservaciones { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
