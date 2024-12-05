using System;
using System.ComponentModel.DataAnnotations;

namespace pruebahotel.Data.Models
{
    public class Habitacion
    {
        [Key]
        public int Id_habitacion { get; set; }
         public int id_hotel { get; set; }
        [Required]
        public int Numero_habitacion { get; set; }
        [Required]
        public string tipo { get; set; }
        [Required]
        public int capacidad { get; set; }
        [Required]
        public int precio_noche { get; set; }
        [Required]
        [RegularExpression("Disponible|Ocupada|Mantenimiento", ErrorMessage = "El estado de la habitación debe ser 'Disponible', 'Ocupada' o 'Mantenimiento'.")]
        public string estado { get; set; }

        // Relación con hotel
        public Hotel Hotel { get; set; }

    }
}
