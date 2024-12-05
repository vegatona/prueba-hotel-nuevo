using pruebahotel.Data.Models;
using System.Collections.Generic;

namespace pruebahotel.Data.ViewModels
{
    public class DetallesReservaVM
    {
        public int IdReserva { get; set; }
        public int IdHabitacion { get; set; }

        // Lista de detalles de la reservación
        public List<DetallesReservaVM> DetallesReservacion { get; set; }
    }
}
