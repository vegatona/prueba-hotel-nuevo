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
        public DbSet<DetalleReservacion> DetallesReservacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de llaves foráneas
            modelBuilder.Entity<Habitacion>()
    .HasOne(h => h.Hotel)  // Relación con la entidad Hotel
    .WithMany()             // Hotel puede tener muchas habitaciones
    .HasForeignKey(h => h.id_hotel); // La clave foránea es IdHotel


            modelBuilder.Entity<reservaciones>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservaciones)
                .HasForeignKey(r => r.IdUsuario);

            modelBuilder.Entity<DetalleReservacion>()
                .HasOne(d => d.Reservaciones)
                .WithMany(r => r.DetallesReservacion)
                .HasForeignKey(d => d.IdReserva);

            modelBuilder.Entity<DetalleReservacion>()
                .HasOne(d => d.Habitacion)
                .WithMany()
                .HasForeignKey(d => d.IdHabitacion);
        }

    }
}
