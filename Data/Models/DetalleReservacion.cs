using System.ComponentModel.DataAnnotations;

namespace pruebahotel.Data.Models
{
    public class DetalleReservacion
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdReserva { get; set; }
        public int IdHabitacion { get; set; }

        // Relación con reservación y habitación
        public reservaciones Reservaciones { get; set; }
        public Habitacion Habitacion { get; set; }
    }
}
