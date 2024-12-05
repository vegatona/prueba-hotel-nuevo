using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pruebahotel.Data.ViewModels
{
    public class HabitacionVM
    {
        public int id_hotel { get; set; }
        public int Numero_habitacion { get; set; }
        public string tipo { get; set; }
        public int capacidad { get; set; }
        public int precio_noche { get; set; }
        [RegularExpression("Disponible|Ocupada|Mantenimiento", ErrorMessage = "El estado de la habitación debe ser 'Disponible', 'Ocupada' o 'Mantenimiento'.")]
        public string estado { get; set; }
    }
}
