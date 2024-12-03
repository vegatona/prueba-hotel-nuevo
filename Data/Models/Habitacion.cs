using System;
using System.ComponentModel.DataAnnotations;

namespace pruebahotel.Data.Models
{
    public class Habitacion
    {
        [Key]
        public int Id_habitacion { get; set; }
        public int Numero_habitacion { get; set; }
        public string tipo { get; set; }
        public int capacidad { get; set; }
        public int precio_noche { get; set; }
        public string estado { get; set; }
    }
}
