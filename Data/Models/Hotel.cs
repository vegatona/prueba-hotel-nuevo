using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pruebahotel.Data.Models
{
    public class Hotel
    {
        [Key]
        public int id_hotel { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string direccion { get; set; }
        public int telefono { get; set; }
        // Validación del formato para el campo horarios
        [RegularExpression(@"Check-in: \d{2}:\d{2}, Check-out: \d{2}:\d{2}", ErrorMessage = "El formato de horarios debe ser 'Check-in: HH:mm, Check-out: HH:mm'.")]
        public string horarios { get; set; }
        public string descripcion { get; set; }

        // Relación con habitaciones
        public ICollection<Habitacion> Habitaciones { get; set; }

    }
}
